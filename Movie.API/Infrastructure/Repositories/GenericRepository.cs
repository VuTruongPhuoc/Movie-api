
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

        public Task<bool> InsertAsync(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }
        public async Task SaveChangeAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
