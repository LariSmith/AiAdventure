using AiAdventure.Data;
using AiAdventure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AiAdventure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _context;
        protected readonly DbSet<T> _set;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _set.Where(predicate).ToListAsync();
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _set.SingleOrDefaultAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _set.AddRangeAsync(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(T entity)
        {
            _set.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _set.RemoveRange(entities);
            await Task.CompletedTask;
        }
    }
}
