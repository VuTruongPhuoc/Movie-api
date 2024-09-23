using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ITrackRepository : IGenericRepository<Track> {
        Task<PaginatedList<Track>> GetAllAsync(int pageNumber, int pageSize, string userId);
    }
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Track> _trackSet;
        public TrackRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _trackSet = _dbContext.Set<Track>();
        }
        public async Task<PaginatedList<Track>> GetAllAsync(int pageNumber, int pageSize, string userId)
        {
            var tracks = await _trackSet.Where(x => x.UserId == userId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = tracks.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Track>(tracks, pageNumber, totalPages);
        }
    }
}
