using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Domain.Entities
{
    public class BookBorrowingDetail : BaseEntity
    {
        [Required]
        public required Guid BookBorrowingId { get; set; }

        [Required]
        public virtual required BookBorrowing BookBorrowing { get; set; }

        [Required]
        public required Guid BookId { get; set; }

        [Required]
        public virtual required Book Book { get; set; }
    }
}