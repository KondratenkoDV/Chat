using Domain.Common;

namespace API.DTOs.Comment
{
    public class QueryPaginationDto : PaginationParameters
    {
        public bool UserName { get; set; } = false;

        public bool Email { get; set; } = false;

        public bool SortDown { get; set; } = true;
    }
}
