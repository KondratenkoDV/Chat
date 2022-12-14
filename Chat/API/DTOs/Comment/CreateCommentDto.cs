namespace API.DTOs.Comment
{
    public class CreateCommentDto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string? HomePage { get; set; }

        public string Text { get; set; }

        public string Ip { get; set; }

        public string BrowserData { get; set; }

        public int? ParentId { get; set; }
    }
}
