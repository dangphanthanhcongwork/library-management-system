using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Domain.Entities;
using LibraryManagementSystem.Infrastucture.Data;
using LibraryManagementSystem.Infrastucture.Interfaces;

namespace LibraryManagementSystem.Infrastucture.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly LibraryContext _context;
        private DbSet<T> _entities;
        private string _entityName;

        public BaseRepository(LibraryContext context)
        {
            _context = context;
            _entities = context.Set<T>();
            _entityName = typeof(T).Name;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _entities.FindAsync(id) ?? throw new KeyNotFoundException($"{_entityName} with id {id} not found.");
            return entity;
        }

        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid id, T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                {
                    throw new KeyNotFoundException($"{_entityName} with id {id} not found.");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _entities.FindAsync(id) ?? throw new KeyNotFoundException($"{_entityName} with id {id} not found.");
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _entities.AnyAsync(e => e.Id.Equals(id));
        }
    }
}