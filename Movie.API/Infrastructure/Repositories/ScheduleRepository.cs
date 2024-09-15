using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
    }
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
