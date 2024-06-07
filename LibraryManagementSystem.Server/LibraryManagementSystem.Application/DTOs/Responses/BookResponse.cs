namespace LibraryManagementSystem.Application.DTOs.Responses
{
    public class BookResponse
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Authors { get; set; }
        public string? Publisher { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string? Description { get; set; }
        public string? ISBN { get; set; }
        public required int PageCount { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Language { get; set; }
    }
}