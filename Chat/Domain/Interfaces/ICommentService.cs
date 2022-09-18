using System;

namespace Domain.Interfaces
{
    public interface ICommentService
    {
        Task<int> AddAsync(
            string userName,
            string email,
            string? homePage,
            string text,
            string ip,
            string browserData,
            int? parentId,
            CancellationToken cancellationToken);

        Task<IEnumerable<Сomment>> SelectingParentCommentsAsync();

        Task<IEnumerable<Сomment>> SelectingCommentsAsync();
    }
}
