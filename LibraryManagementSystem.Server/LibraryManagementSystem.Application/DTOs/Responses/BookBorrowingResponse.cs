using LibraryManagementSystem.Domain.Enums;

namespace LibraryManagementSystem.Application.DTOs.Responses
{
    public class BookBorrowingResponse
    {
        public Guid Id { get; set; }
        public required Guid RequestorId { get; set; }
        public DateTime RequestedDate { get; set; }
        public RequestStatus Status { get; set; }
        public Guid? ApproverId { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public required ICollection<Guid> BookIds { get; set; }
    }
}