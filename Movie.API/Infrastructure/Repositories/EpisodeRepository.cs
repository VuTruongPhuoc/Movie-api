using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IEpisodeRepository : IGenericRepository<Episode> { }
    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
