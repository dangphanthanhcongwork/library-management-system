using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        [MaxLength(150)]
        public required string Title { get; set; }

        [MaxLength(100)]
        public string? Authors { get; set; }

        [MaxLength(100)]
        public string? Publisher { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PublishedDate { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(17)]
        public string? ISBN { get; set; }

        [Required]
        [Range(0, 4000)]
        public required int PageCount { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        [MaxLength(10)]
        public string? Language { get; set; }

        public virtual ICollection<BookBorrowingDetail>? BookBorrowingDetails { get; set; }
    }
}