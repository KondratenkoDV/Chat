using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Services.Сomment
{
    public class СommentService
    {
        private readonly IDbContext _dbContext;

        public СommentService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(
            string userName,
            string email,
            string homePage,
            string text,
            string ip,
            string browserData,
            int parentId,
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

        public async Task<IEnumerable<Domain.Сomment>> SelectingParentCommentsAsync()
        {
            return await _dbContext.Сomments.Where(c => c.ParentId.HasValue == false).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Сomment>> SelectingCommentsAsync()
        {
            return await _dbContext.Сomments.Where(c => c.ParentId.HasValue).ToListAsync();
        }
    }
}
