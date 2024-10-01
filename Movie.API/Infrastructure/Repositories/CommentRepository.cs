using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetAllAsync(int filmId);
    }
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Comment> _commentSet;
        public CommentRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _commentSet = _dbContext.Set<Comment>();
        }
        public async Task<List<Comment>> GetAllAsync(int filmId)
        {
            var comments = await _commentSet.Where(x => x.FilmId == filmId).ToListAsync();

            return comments;
        }
    }
}
