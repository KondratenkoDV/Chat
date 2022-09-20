using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.Common
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Entities { get; }

        public PaginationMetadata PaginationMetadata { get; }

        public PagedResponse(
            IEnumerable<T> items,
            int count,
            int pageNumber,
            int pageSize)
        {
            PaginationMetadata = new PaginationMetadata(
                count,
                pageNumber,
                pageSize);
            Entities = items;
        }

        public static async Task<PagedResponse<T>> CreateAsync(
            IQueryable<T> source,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken)
        {
            var count = source.Count();
            var items = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);

            return new PagedResponse<T>(
                items,
                count,
                pageNumber,
                pageSize);
        }
    }
}
