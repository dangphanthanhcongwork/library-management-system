using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllAsync();
        Task<CategoryResponse> GetByIdAsync(Guid id);
        Task AddAsync(CategoryRequest categoryRequest);
        Task UpdateAsync(Guid id, CategoryRequest categoryRequest);
        Task DeleteAsync(Guid id);
    }
}