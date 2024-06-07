using LibraryManagementSystem.Infrastucture.Interfaces;
using LibraryManagementSystem.Application.Interfaces;
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application.DTOs.Responses;
using LibraryManagementSystem.Application.DTOs.Requests;

namespace LibraryManagementSystem.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllAsync()
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }

        public async Task<CategoryResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var category = await _repository.GetByIdAsync(id);
                return _mapper.Map<CategoryResponse>(category);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }

        public async Task AddAsync(CategoryRequest categoryRequest)
        {
            var category = _mapper.Map<Category>(categoryRequest);
            category.CreatedAt = DateTime.UtcNow;
            await _repository.AddAsync(category);
        }

        public async Task UpdateAsync(Guid id, CategoryRequest categoryRequest)
        {
            try
            {
                var category = _mapper.Map<Category>(categoryRequest);
                category.Id = id;
                category.LastModifiedAt = DateTime.UtcNow;
                await _repository.UpdateAsync(id, category);
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