namespace API.DTOs.Comment
{
    public class SelectedParentCommentDto
    {
        public int Id { get; set; }

        public string SelectedUserName { get; set; }

        public string SelectedEmail { get; set; }

        public string? SelectedHomePage { get; set; }

        public string SelectedText { get; set; }

        public string SelectedIp { get; set; }

        public string SelectedBrowserData { get; set; }

        public DateTime SelectedDateAdded { get; set; }
    }
}
