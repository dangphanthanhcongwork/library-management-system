using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}