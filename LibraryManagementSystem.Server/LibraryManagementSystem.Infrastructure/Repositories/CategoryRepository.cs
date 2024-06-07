using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastucture.Data;
using LibraryManagementSystem.Infrastucture.Interfaces;

namespace LibraryManagementSystem.Infrastucture.Implementations
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryContext context) : base(context)
        {
        }
    }
}