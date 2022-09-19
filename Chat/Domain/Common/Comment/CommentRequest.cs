using System;

namespace Domain.Common.Comment
{
    public class CommentRequest : PaginationParameters
    {
        public bool UserName { get; set; } = false;

        public bool Email { get; set; } = false;

        public bool SortDown { get; set; } = true;
    }
}
