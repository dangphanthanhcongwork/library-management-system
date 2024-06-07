using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Application.DTOs.Requests
{
    public class CategoryRequest
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
    }
}