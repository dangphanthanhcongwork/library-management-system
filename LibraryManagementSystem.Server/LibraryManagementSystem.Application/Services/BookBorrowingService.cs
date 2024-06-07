using LibraryManagementSystem.Infrastucture.Interfaces;
using LibraryManagementSystem.Application.Interfaces;
using AutoMapper;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Application.DTOs.Responses;
using LibraryManagementSystem.Application.DTOs.Requests;

namespace LibraryManagementSystem.Application.Services
{
    public class BookBorrowingService : IBookBorrowingService
    {
        private readonly IBaseRepository<Book> _bookRepository;
        private readonly IBaseRepository<BookBorrowing> _bookBorrowingRepository;
        private readonly IBaseRepository<BookBorrowingDetail> _bookBorrowingDetailRepository;

        private readonly IMapper _mapper;

        public BookBorrowingService(
            IBaseRepository<Book> bookRepository,
            IBaseRepository<BookBorrowing> bookBorrowingRepository,
            IBaseRepository<BookBorrowingDetail> bookBorrowingDetailRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _bookBorrowingRepository = bookBorrowingRepository;
            _bookBorrowingDetailRepository = bookBorrowingDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookBorrowingResponse>> GetAllAsync()
        {
            var bookBorrowings = await _bookBorrowingRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookBorrowingResponse>>(bookBorrowings);
        }

        public async Task<BookBorrowingResponse> GetByIdAsync(Guid id)
        {
            try
            {
                var bookBorrowing = await _bookBorrowingRepository.GetByIdAsync(id);
                return _mapper.Map<BookBorrowingResponse>(bookBorrowing);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }

        public async Task AddAsync(BookBorrowingRequest bookBorrowingRequest)
        {
            var bookBorrowing = _mapper.Map<BookBorrowing>(bookBorrowingRequest);
            bookBorrowing.CreatedAt = DateTime.UtcNow;

            foreach (var bookId in bookBorrowingRequest.BookIds)
            {
                var book = await _bookRepository.GetByIdAsync(bookId);
                var bookBorrowingDetail = new BookBorrowingDetail
                {
                    BookBorrowingId = bookBorrowing.Id,
                    BookBorrowing = bookBorrowing,
                    BookId = bookId,
                    Book = book
                };
                await _bookBorrowingDetailRepository.AddAsync(bookBorrowingDetail);
            }

            await _bookBorrowingRepository.AddAsync(bookBorrowing);
        }

        public async Task UpdateAsync(Guid id, BookBorrowingRequest bookBorrowingRequest)
        {
            try
            {
                var bookBorrowing = _mapper.Map<BookBorrowing>(bookBorrowingRequest);
                bookBorrowing.Id = id;
                bookBorrowing.LastModifiedAt = DateTime.UtcNow;

                var existingBookBorrowingDetails = await _bookBorrowingDetailRepository.GetAllAsync();
                var detailsToDelete = existingBookBorrowingDetails.Where(detail => detail.BookBorrowingId == id).ToList();
                foreach (var bookBorrowingDetail in detailsToDelete)
                {
                    await _bookBorrowingDetailRepository.DeleteAsync(bookBorrowingDetail.Id);
                }
                foreach (var bookId in bookBorrowingRequest.BookIds)
                {
                    var book = await _bookRepository.GetByIdAsync(bookId);
                    var bookBorrowingDetail = new BookBorrowingDetail
                    {
                        BookBorrowingId = bookBorrowing.Id,
                        BookBorrowing = bookBorrowing,
                        BookId = bookId,
                        Book = book
                    };
                    await _bookBorrowingDetailRepository.AddAsync(bookBorrowingDetail);
                }

                await _bookBorrowingRepository.UpdateAsync(id, bookBorrowing);
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
                var existingBookBorrowingDetails = await _bookBorrowingDetailRepository.GetAllAsync();
                var detailsToDelete = existingBookBorrowingDetails.Where(detail => detail.BookBorrowingId == id).ToList();
                foreach (var bookBorrowingDetail in detailsToDelete)
                {
                    await _bookBorrowingDetailRepository.DeleteAsync(bookBorrowingDetail.Id);
                }

                await _bookBorrowingRepository.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }

        public async Task RequestAsync(BookBorrowingRequest bookBorrowingRequest)
        {
            // Check if the user has already borrowed the maximum number of books
            if (bookBorrowingRequest.BookIds.Count > 5)
            {
                throw new InvalidOperationException("You can borrow up to 5 books in one request.");
            }

            // Check if the user has reached the borrowing limit for the month
            var monthStart = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            var monthEnd = monthStart.AddMonths(1).AddDays(-1);

            var existingBorrowings = await _bookBorrowingRepository.GetAllAsync();
            var userBorrowingsThisMonth = existingBorrowings
                .Where(b => b.RequestorId == bookBorrowingRequest.RequestorId && b.RequestedDate >= monthStart && b.RequestedDate <= monthEnd);

            if (userBorrowingsThisMonth.Count() >= 3)
            {
                throw new InvalidOperationException("You have reached the limit of 3 borrowing requests for this month.");
            }

            var bookBorrowing = _mapper.Map<BookBorrowing>(bookBorrowingRequest);
            bookBorrowing.RequestedDate = DateTime.UtcNow;
            bookBorrowing.CreatedAt = DateTime.UtcNow;

            foreach (var bookId in bookBorrowingRequest.BookIds)
            {
                var book = await _bookRepository.GetByIdAsync(bookId);
                var bookBorrowingDetail = new BookBorrowingDetail
                {
                    BookBorrowingId = bookBorrowing.Id,
                    BookBorrowing = bookBorrowing,
                    BookId = bookId,
                    Book = book
                };
                await _bookBorrowingDetailRepository.AddAsync(bookBorrowingDetail);
            }

            await _bookBorrowingRepository.AddAsync(bookBorrowing);
        }

        public async Task ApproveAsync(Guid id, BookBorrowingRequest bookBorrowingRequest)
        {
            try
            {
                var bookBorrowing = _mapper.Map<BookBorrowing>(bookBorrowingRequest);
                bookBorrowing.Id = id;
                bookBorrowingRequest.ApprovedDate = DateTime.UtcNow;
                bookBorrowing.LastModifiedAt = DateTime.UtcNow;

                var existingBookBorrowingDetails = await _bookBorrowingDetailRepository.GetAllAsync();
                var detailsToDelete = existingBookBorrowingDetails.Where(detail => detail.BookBorrowingId == id).ToList();
                foreach (var bookBorrowingDetail in detailsToDelete)
                {
                    await _bookBorrowingDetailRepository.DeleteAsync(bookBorrowingDetail.Id);
                }
                foreach (var bookId in bookBorrowingRequest.BookIds)
                {
                    var book = await _bookRepository.GetByIdAsync(bookId);
                    var bookBorrowingDetail = new BookBorrowingDetail
                    {
                        BookBorrowingId = bookBorrowing.Id,
                        BookBorrowing = bookBorrowing,
                        BookId = bookId,
                        Book = book
                    };
                    await _bookBorrowingDetailRepository.AddAsync(bookBorrowingDetail);
                }

                await _bookBorrowingRepository.UpdateAsync(id, bookBorrowing);
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
        }
    }
}