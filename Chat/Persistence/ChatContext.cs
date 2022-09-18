using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using System;

namespace Persistence
{
    public class ChatContext : DbContext
    {
        public DbSet<Сomment> Сomments { get; set; } = null!;

        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new СommentConfiguration());
        }
    }
}
