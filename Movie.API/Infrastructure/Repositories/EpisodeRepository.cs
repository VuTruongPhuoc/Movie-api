using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IEpisodeRepository : IGenericRepository<Episode>
    {
        Task<List<Episode>> GetEpisodesByFilm(int filmId);
        Task<List<Episode>> GetAllAsync();
        Task<List<Episode>> GetByNameAsync(string name);
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
        public async Task<List<Episode>> GetEpisodesByFilm(int filmId)
        {
            return await _episodeSet.Where(x => x.FilmId == filmId).ToListAsync();
        }

        public async Task<List<Episode>> GetByNameAsync(string name)
        {
            return await _episodeSet.Where(x => x.Name == name).ToListAsync();
        }

        public async Task<List<Episode>> GetAllAsync()
        {
            return await _episodeSet.ToListAsync();
        }
    }
}
