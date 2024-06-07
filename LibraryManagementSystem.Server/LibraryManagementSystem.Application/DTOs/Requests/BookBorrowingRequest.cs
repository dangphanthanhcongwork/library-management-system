using System.ComponentModel.DataAnnotations;
using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Application.DTOs.Requests
{
    public class BookBorrowingRequest
    {
        [Required]
        public required Guid RequestorId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RequestedDate { get; set; }

        [Required]
        public RequestStatus Status { get; set; }

        public Guid? ApproverId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ApprovedDate { get; set; }

        [Required]
        public required ICollection<Guid> BookIds { get; set; }
    }
}