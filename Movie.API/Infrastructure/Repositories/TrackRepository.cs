using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ITrackRepository : IGenericRepository<Track> { }
    public class TrackRepository : GenericRepository<Track>, ITrackRepository
    {
        public TrackRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
