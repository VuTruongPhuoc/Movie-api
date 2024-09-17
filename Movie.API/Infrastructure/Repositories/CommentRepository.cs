using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment> { }
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(MovieDbContext dbContext) : base(dbContext)
        {
        }
    }
}
