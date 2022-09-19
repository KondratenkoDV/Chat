
using Domain.Common;
using Domain.Common.Comment;
using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly IDbContext _dbContext;

        public CommentService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(
            string userName,
            string email,
            string? homePage,
            string text,
            string ip,
            string browserData,
            int? parentId,
            CancellationToken cancellationToken)
        {
            var comment = new Domain.Сomment(
                userName,
                email,
                homePage,
                text,
                ip,
                browserData,
                parentId);

            await _dbContext.Сomments.AddAsync(comment);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return comment.Id;
        }

        public async Task<PagedResponse<Сomment>> SelectingParentCommentsAsync(
            CommentRequest request, 
            CancellationToken cancellationToken)
        {
            var comments = _dbContext.Сomments
                .Where(c => c.ParentId.HasValue == false)
                .AsNoTracking();

            comments = Sort(request, comments).AsNoTracking();

            return await PagedResponse<Сomment>.CreateAsync(
                comments,
                request.PaginationParameters.PageNumber,
                request.PaginationParameters.PageSize,
                cancellationToken);
        }

        public async Task<IEnumerable<Сomment>> SelectingCommentsAsync(int parentId, CancellationToken cancellationToken)
        {
            return await _dbContext.Сomments
                .Where(c => c.ParentId == parentId)
                .OrderBy(c => c.DateAdded)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        private IQueryable<Сomment> Sort(CommentRequest request, IQueryable<Сomment> сomments)
        {
            if (request.UserName)
            {
                switch(request.SortDown)
                {
                    case true:

                        return сomments
                            .OrderBy(c => c.UserName);

                    case false:

                        return сomments
                            .OrderByDescending(c => c.UserName);
                }
            }

            if(request.Email)
            {
                switch (request.SortDown)
                {
                    case true:

                        return сomments
                            .OrderBy(c => c.Email);

                    case false:

                        return сomments
                            .OrderByDescending(c => c.Email);
                }
            }

            if (request.SortDown == false)
            {
                return сomments
                    .OrderByDescending(c => c.DateAdded);
            }

            return сomments
                    .OrderBy(c => c.DateAdded);
        }
    }
}
