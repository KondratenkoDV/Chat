using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Interfaces
{
    public interface IDbContext
    {
        DbSet<Сomment> Сomments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
