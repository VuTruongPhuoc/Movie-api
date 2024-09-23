using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IEpisodeRepository : IGenericRepository<Episode>
    {
        Task<PaginatedList<Episode>> GetAllAsync(int pageNumber, int pageSize, int filmId);
    }
    public class EpisodeRepository : GenericRepository<Episode>, IEpisodeRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Episode> _episodeSet;
        public EpisodeRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _episodeSet = _dbContext.Set<Episode>();
        }
        public async Task<PaginatedList<Episode>> GetAllAsync(int pageNumber, int pageSize, int filmId)
        {
            var episodes = await _episodeSet.Where(x => x.FilmId == filmId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = episodes.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Episode>(episodes, pageNumber, totalPages);
        }
    }
}
