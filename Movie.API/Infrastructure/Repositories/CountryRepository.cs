using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {

        Task<List<Country>> GetAllAsync();
        Task<List<Country>> GetByNameAsync(string name);
        
    }
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Country> _countrySet;
        public CountryRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _countrySet = _dbContext.Set<Country>();

        }
        public async Task<List<Country>> GetAllAsync()
        {
            return await _countrySet.ToListAsync();
        }

        public async Task<List<Country>> GetByNameAsync(string name)
        {
            return await _countrySet.Where(x => x.Name == name).ToListAsync();
        }


    }

}