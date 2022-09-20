
using API.DTOs.Common;

namespace API.DTOs.Comment
{
    public class QueryPaginationDto : PaginationParametersDto
    {
        public bool UserName { get; set; } = false;

        public bool Email { get; set; } = false;

        public bool SortDown { get; set; } = true;
    }
}
