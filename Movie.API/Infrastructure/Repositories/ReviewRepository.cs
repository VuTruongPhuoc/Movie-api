using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<PaginatedList<Review>> GetAllAsync(int pageNumber, int pageSize, int filmId);
    }
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Review> _reviewSet;
        public ReviewRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _reviewSet = _dbContext.Set<Review>();
        }
        public async Task<PaginatedList<Review>> GetAllAsync(int pageNumber, int pageSize, int filmId)
        {
            var reviews = await _reviewSet.Where(x => x.FilmId == filmId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = reviews.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Review>(reviews, pageNumber, totalPages);
        }
    }
}
