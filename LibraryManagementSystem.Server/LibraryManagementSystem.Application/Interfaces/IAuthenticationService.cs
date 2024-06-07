using LibraryManagementSystem.Application.DTOs.Responses;

namespace LibraryManagementSystem.Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> VerifyPasswordHash(string password, string passwordHash);

        Task<string?> Authenticate(string username, string password);

        Task<string> GenerateJwtToken(UserResponse user);

        Task<UserResponse> GetUserByUserName(String username);
    }
}