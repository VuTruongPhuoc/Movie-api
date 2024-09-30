using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ISectionRepository : IGenericRepository<Section>
    {
        Task<List<Section>> GetAllAsync();
        Task<List<Section>> GetByNameAsync(string name);
    }
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Section> _sectionSet;
        public SectionRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _sectionSet = _dbContext.Set<Section>();

        }

        public async Task<List<Section>> GetAllAsync()
        {
            return await _sectionSet.ToListAsync();
        }

        public async Task<List<Section>> GetByNameAsync(string name)
        {
            return await _sectionSet.Where(x => x.Name == name).ToListAsync();
        }


    }
}