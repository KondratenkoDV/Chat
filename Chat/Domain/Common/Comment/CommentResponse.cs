using System;

namespace Domain.Common.Comment
{
    public class CommentResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string? HomePage { get; set; }

        public string Text { get; set; }

        public string Ip { get; set; }

        public string BrowserData { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
