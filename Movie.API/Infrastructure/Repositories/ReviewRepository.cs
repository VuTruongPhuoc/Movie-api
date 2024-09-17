using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review> { }
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
