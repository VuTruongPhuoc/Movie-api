using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> ChangeRoleAsync(string userName, string roleName);
        Task<bool> DeleteUserAsync(string username);
    }
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        private readonly MovieDbContext _dbContext;
        private readonly UserManager<User> _userManager; 
        private readonly RoleManager<Role> _roleManager;
        public UserRepository(MovieDbContext dbContext,UserManager<User> userManager, RoleManager<Role> roleManager) : base(dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<bool> ChangeRoleAsync(string userName, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var userrole = await _dbContext.UserRoles.SingleOrDefaultAsync(x => x.UserId == user.Id);
            var currentRole = await _roleManager.FindByIdAsync(userrole.RoleId);
            await _userManager.RemoveFromRoleAsync(user, currentRole.Name.ToString());
            await _userManager.AddToRoleAsync(user, roleName);
            return true;
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
