using LibraryManagementSystem.Infrastucture.Interfaces;
using LibraryManagementSystem.Application.Interfaces;
using AutoMapper;
using LibraryManagementSystem.Application.DTOs.Responses;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LibraryManagementSystem.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public AuthenticationService(IConfiguration configuration, IUserRepository repository, IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> VerifyPasswordHash(string password, string passwordHash)
        {
            return await Task.Run(() => BCrypt.Net.BCrypt.Verify(password, passwordHash));
        }

        public async Task<string?> Authenticate(string username, string password)
        {
            var userResponse = await GetUserByUserName(username);

            if (userResponse == null)
                return null;

            bool isMatched = await VerifyPasswordHash(password, userResponse.PasswordHash);

            if (!isMatched)
                return null;

            return await GenerateJwtToken(userResponse);
        }

        public async Task<string> GenerateJwtToken(UserResponse user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var secretKey = _configuration["Jwt:Key"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim(ClaimTypes.Email, user.EmailAddress),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                ]),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return await Task.Run(() => tokenHandler.WriteToken(token));
        }

        public async Task<UserResponse> GetUserByUserName(String username)
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<UserResponse>(users
                .FirstOrDefault(u => u.Username.Equals(username)));
        }
    }
}