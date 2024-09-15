using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {

    }
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
