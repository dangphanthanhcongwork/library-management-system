using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastucture.Data;
using LibraryManagementSystem.Infrastucture.Interfaces;

namespace LibraryManagementSystem.Infrastucture.Implementations
{
    public class BookBorrowingRepository : BaseRepository<BookBorrowing>, IBookBorrowingRepository
    {
        public BookBorrowingRepository(LibraryContext context) : base(context)
        {
        }
    }
}