using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IBookBorrowingService
    {
        Task<IEnumerable<BookBorrowingResponse>> GetAllAsync();
        Task<BookBorrowingResponse> GetByIdAsync(Guid id);
        Task AddAsync(BookBorrowingRequest bookBorrowingRequest);
        Task UpdateAsync(Guid id, BookBorrowingRequest bookBorrowingRequest);
        Task DeleteAsync(Guid id);
        Task RequestAsync(BookBorrowingRequest bookBorrowingRequest);
        Task ApproveAsync(Guid id, BookBorrowingRequest bookBorrowingRequest);
    }
}