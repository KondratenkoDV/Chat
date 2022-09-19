using System;

namespace Domain.Common
{
    public class PagedRequest
    {
        public PaginationParameters PaginationParameters { get; private set; }

        public PagedRequest()
        {
            PaginationParameters = new PaginationParameters();
        }
    }
}
