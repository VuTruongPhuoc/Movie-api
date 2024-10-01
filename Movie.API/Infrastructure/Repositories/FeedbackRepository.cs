using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IFeedbackRepository : IGenericRepository<Feedback>
    {
        Task<List<Feedback>> GetAllAsync(int commentId);
    }
    public class FeedbackRepository : GenericRepository<Feedback>, IFeedbackRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Feedback> _feedbackSet;
        public FeedbackRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _feedbackSet = _dbContext.Set<Feedback>();
        }

        public  async Task<List<Feedback>> GetAllAsync(int commentId)
        {
            return await _feedbackSet.Where(x => x.CommentId == commentId).ToListAsync();
        }
    }
}
