using LibraryManagementSystem.Infrastucture.Interfaces;
using LibraryManagementSystem.Application.Interfaces;
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application.DTOs.Responses;
using LibraryManagementSystem.Application.DTOs.Requests;

namespace LibraryManagementSystem.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponse>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponse>>(users);
        }

        public async Task<UserResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);
                return _mapper.Map<UserResponse>(user);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }

        public async Task AddAsync(UserRequest userRequest)
        {
            var user = _mapper.Map<User>(userRequest);
            user.CreatedAt = DateTime.UtcNow;
            await _repository.AddAsync(user);
        }

        public async Task UpdateAsync(Guid id, UserRequest userRequest)
        {
            try
            {
                var user = _mapper.Map<User>(userRequest);
                user.Id = id;
                user.LastModifiedAt = DateTime.UtcNow;
                await _repository.UpdateAsync(id, user);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _repository.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }
    }
}