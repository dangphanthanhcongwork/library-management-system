using LibraryManagementSystem.Infrastucture.Interfaces;
using LibraryManagementSystem.Application.Interfaces;
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application.DTOs.Responses;
using LibraryManagementSystem.Application.DTOs.Requests;

namespace LibraryManagementSystem.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookResponse>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookResponse>>(books);
        }

        public async Task<BookResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var book = await _repository.GetByIdAsync(id);
                return _mapper.Map<BookResponse>(book);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }

        public async Task AddAsync(BookRequest bookRequest)
        {
            var book = _mapper.Map<Book>(bookRequest);
            book.CreatedAt = DateTime.UtcNow;
            await _repository.AddAsync(book);
        }

        public async Task UpdateAsync(Guid id, BookRequest bookRequest)
        {
            try
            {
                var book = _mapper.Map<Book>(bookRequest);
                book.Id = id;
                book.LastModifiedAt = DateTime.UtcNow;
                await _repository.UpdateAsync(id, book);
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