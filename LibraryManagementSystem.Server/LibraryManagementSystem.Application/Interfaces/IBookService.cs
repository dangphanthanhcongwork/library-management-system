using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookResponse>> GetAllAsync();
        Task<BookResponse> GetByIdAsync(Guid id);
        Task AddAsync(BookRequest bookRequest);
        Task UpdateAsync(Guid id, BookRequest bookRequest);
        Task DeleteAsync(Guid id);
    }
}