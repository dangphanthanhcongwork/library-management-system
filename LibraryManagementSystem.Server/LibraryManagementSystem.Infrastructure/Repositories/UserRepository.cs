using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastucture.Data;
using LibraryManagementSystem.Infrastucture.Interfaces;

namespace LibraryManagementSystem.Infrastucture.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LibraryContext context) : base(context)
        {
        }
    }
}