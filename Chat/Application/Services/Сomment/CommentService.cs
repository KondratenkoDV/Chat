
using Domain.Common;
using Domain;
using Domain.Common.Comment;
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
            var comment = new Сomment(
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
                .Where(c => !c.ParentId.HasValue)
                .AsNoTracking();

            return await GetPagedResponseAsync(request, comments, cancellationToken);
        }

        public async Task<PagedResponse<Сomment>> SelectingCommentsAsync(
            int parentId,
            CommentRequest request,
            CancellationToken cancellationToken)
        {
            var comments = _dbContext.Сomments
                .Where(c => c.ParentId == parentId)
                .AsNoTracking();

            return await GetPagedResponseAsync(request, comments, cancellationToken);
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

        private async Task<PagedResponse<Сomment>> GetPagedResponseAsync(
            CommentRequest request,
            IQueryable<Сomment> сomments,
            CancellationToken cancellationToken)
        {
            сomments = Sort(request, сomments).AsNoTracking();

            return await PagedResponse<Сomment>.CreateAsync(
                сomments,
                request.PageNumber,
                request.PageSize,
                cancellationToken);
        }
    }
}
