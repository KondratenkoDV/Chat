using Domain.Common;

namespace API.DTOs.Common
{
    public class PagedDto<T>
    {
        public IEnumerable<T>? Entities { get; set; }

        public PaginationMetadata? PaginationMetadata { get; set; }
    }
}
