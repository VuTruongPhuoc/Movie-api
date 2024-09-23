using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<PaginatedList<Comment>> GetAllAsync(int pageNumber, int pageSize, int filmId);
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
        public async Task<PaginatedList<Comment>> GetAllAsync(int pageNumber, int pageSize, int filmId)
        {
            var comments = await _commentSet.Where(x => x.FilmId == filmId).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var count = comments.Count();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Comment> ( comments,pageNumber , totalPages );
        }
    }
}
