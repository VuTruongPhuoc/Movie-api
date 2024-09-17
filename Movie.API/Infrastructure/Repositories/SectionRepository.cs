using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ISectionRepository : IGenericRepository<Section>
    {

    }
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
