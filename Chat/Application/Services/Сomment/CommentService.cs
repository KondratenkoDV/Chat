
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

        public async Task<PagedResponse<Сomment, CommentResponse>> SelectingParentCommentsAsync(
            CommentRequest request, 
            CancellationToken cancellationToken)
        {
            var comments = await Sort(request);

            return await PagedResponse<Сomment, CommentResponse>.CreateAsync(
                Map,
                comments,
                request.PaginationParameters.PageNumber,
                request.PaginationParameters.PageSize,
                cancellationToken);
        }

        public async Task<IEnumerable<Сomment>> SelectingCommentsAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.Сomments
                .Where(c => c.ParentId.HasValue)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        private CommentResponse Map(Сomment сomment)
        {
            return new CommentResponse()
            {
                Id = сomment.Id,
                UserName = сomment.UserName,
                Email = сomment.Email,
                HomePage = сomment.HomePage,
                Text = сomment.Text,
                Ip = сomment.Ip,
                BrowserData = сomment.BrowserData,
                DateAdded = сomment.DateAdded
            };
        }

        private async Task<IQueryable<Сomment>> Sort(CommentRequest request)
        {
            if (request.UserName)
            {
                switch(request.SortDown)
                {
                    case true:

                        return _dbContext.Сomments
                            .OrderByDescending(c => c.UserName)
                            .AsNoTracking();

                    case false:

                        return _dbContext.Сomments
                            .OrderBy(c => c.UserName)
                            .AsNoTracking();
                }
            }

            if(request.Email)
            {
                switch (request.SortDown)
                {
                    case true:

                        return _dbContext.Сomments
                            .OrderByDescending(c => c.Email)
                            .AsNoTracking();

                    case false:

                        return _dbContext.Сomments
                            .OrderBy(c => c.Email)
                            .AsNoTracking();
                }
            }

            if (request.DateAdded)
            {
                switch (request.SortDown)
                {
                    case true:

                        return _dbContext.Сomments
                            .OrderByDescending(c => c.DateAdded)
                            .AsNoTracking();

                    case false:

                        return _dbContext.Сomments
                            .OrderBy(c => c.DateAdded)
                            .AsNoTracking();
                }
            }

            return _dbContext.Сomments
                .Where(c => c.ParentId.HasValue == false)
                .AsNoTracking();
        }
    }
}
