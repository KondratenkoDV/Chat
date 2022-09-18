using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Persistence.Configurations
{
    internal class СommentConfiguration : IEntityTypeConfiguration<Сomment>
    {
        public void Configure(EntityTypeBuilder<Сomment> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.UserName)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.HomePage)
                .HasMaxLength(255);

            builder
                .Property(c => c.Text)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.Ip)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.BrowserData)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(c => c.DateAdded)
                .IsRequired();
        }
    }
}
