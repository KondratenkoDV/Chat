using System;

namespace Domain.Common.Comment
{
    public class CommentRequest : PagedRequest
    {
        public bool UserName { get; set; } = false;

        public bool Email { get; set; } = false;

        public bool DateAdded { get; set; } = false;

        public bool SortDown { get; set; } = true;
    }
}
