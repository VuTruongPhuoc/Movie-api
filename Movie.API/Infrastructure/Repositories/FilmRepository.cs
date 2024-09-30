using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IFilmRepository : IGenericRepository<Film>
    {
        Task<List<Film>> GetAllAsync();
        Task<List<Film>> GetBySlugAsync(string slug);
    }
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly DbSet<Film> _filmSet;
        public FilmRepository(MovieDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _filmSet = _dbContext.Set<Film>();
          
        }

        public async Task<List<Film>> GetAllAsync()
        {
           return await _filmSet.ToListAsync();
        }

        public async Task<List<Film>> GetBySlugAsync(string slug)
        {
            return await _filmSet.Where(x => x.Slug == slug).ToListAsync();
        }


    }
}
