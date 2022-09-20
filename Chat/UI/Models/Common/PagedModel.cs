namespace UI.Models.Common
{
    public class PagedModel<T>
    {
        public IEnumerable<T>? Entities { get; set; }

        public PaginationMetadata? PaginationMetadata { get; set; }
    }
}
