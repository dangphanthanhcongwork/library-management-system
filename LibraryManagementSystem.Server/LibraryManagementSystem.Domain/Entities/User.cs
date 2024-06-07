using System.ComponentModel.DataAnnotations;
using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public required string PasswordHash { get; set; }

        [Required]
        public UserRole Role { get; set; }

        [Required]
        [MaxLength(100)]
        public required string FullName { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public required string EmailAddress { get; set; }

        [Required]
        [MaxLength(15)]
        [Phone]
        public required string PhoneNumber { get; set; }

        public virtual ICollection<BookBorrowing>? BookBorrowingAsRequester { get; set; }

        public virtual ICollection<BookBorrowing>? BookBorrowingAsApprover { get; set; }
    }
}