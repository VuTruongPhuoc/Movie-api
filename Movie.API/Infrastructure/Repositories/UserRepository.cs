using Microsoft.AspNetCore.Identity;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> DeleteUserAsync(string username);
    }
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly UserManager<User> _userManager;    
        public UserRepository(MovieDbContext dbContext,UserManager<User> userManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public async Task<User> AddAsync(User entity)
        {
            await _userManager.CreateAsync(entity);
            return await Task.FromResult(entity);
        }  
        public async Task<User> UpdateAsync(User entity)
        {
            await _userManager.UpdateAsync(entity);
            return await Task.FromResult(entity);
        }
        public async Task<bool> DeleteUserAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            await _userManager.DeleteAsync(user);
            return await Task.FromResult(true);
        }
    }
}
