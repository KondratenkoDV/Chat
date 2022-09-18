﻿using System;

namespace Domain.Interfaces
{
    public interface IСommentService
    {
        Task<int> AddAsync(
            string userName,
            string email,
            string homePage,
            string text,
            string ip,
            string browserData,
            int parentId,
            CancellationToken cancellationToken);

        Task<IEnumerable<Domain.Сomment>> SelectingParentCommentsAsync();

        Task<IEnumerable<Domain.Сomment>> SelectingCommentsAsync();
    }
}
