using Domain.Common;
using Domain.Common.Comment;
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

        Task<PagedResponse<Сomment>> SelectingParentCommentsAsync(
            CommentRequest request,
            CancellationToken cancellationToken);

        Task<IEnumerable<Сomment>> SelectingCommentsAsync(CancellationToken cancellationToken);
    }
}
