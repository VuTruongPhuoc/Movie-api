
using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;

namespace Movie.API.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return entity;
        }
        public async Task<bool> DeleteAsync(object id)
        {
            var obj = _dbSet.Find(id);
            _dbSet.Remove(obj);
            return true;
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
