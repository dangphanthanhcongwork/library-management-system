using System.ComponentModel.DataAnnotations;
using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Domain.Entities
{
    public class BookBorrowing : BaseEntity
    {
        [Required]
        public required Guid RequestorId { get; set; }

        [Required]
        public virtual required User Requestor { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RequestedDate { get; set; }

        [Required]
        public RequestStatus Status { get; set; }

        public Guid? ApproverId { get; set; }

        public virtual User? Approver { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovedDate { get; set; }

        public virtual ICollection<BookBorrowingDetail>? BookBorrowingDetails { get; set; }
    }
}