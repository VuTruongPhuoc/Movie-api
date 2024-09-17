using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IHistoryRepository : IGenericRepository<History> { }
    public class HistoryRepository : GenericRepository<History>, IHistoryRepository
    {
        public HistoryRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
