using System;

namespace Domain.Common
{
    public class PaginationMetadata
    {
        public int CurrentPage { get; }

        public int TotalPages { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public PaginationMetadata(
            int count,
            int pageNumber,
            int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
