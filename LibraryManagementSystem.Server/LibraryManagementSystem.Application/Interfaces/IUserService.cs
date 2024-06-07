using LibraryManagementSystem.Application.DTOs.Requests;
using LibraryManagementSystem.Application.DTOs.Responses;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAllAsync();
        Task<UserResponse> GetByIdAsync(Guid id);
        Task AddAsync(UserRequest userRequest);
        Task UpdateAsync(Guid id, UserRequest userRequest);
        Task DeleteAsync(Guid id);
    }
}