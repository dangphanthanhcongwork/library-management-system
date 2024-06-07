namespace LibraryManagementSystem.Application.DTOs.Responses
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}