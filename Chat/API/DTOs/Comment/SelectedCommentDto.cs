namespace API.DTOs.Comment
{
    public class SelectedCommentDto : SelectedParentCommentDto
    {
        public int? SelectedParentId { get; set; }
    }
}
