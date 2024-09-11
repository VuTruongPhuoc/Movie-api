using Microsoft.AspNetCore.Identity;
using Movie.API.Infrastructure.Data;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses.DTOs;

namespace Movie.API.Infrastructure.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {    
        
    }
   
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly MovieDbContext _dbContext;
        public readonly RoleManager<Role> _roleManager;
        public RoleRepository(MovieDbContext context , RoleManager<Role> roleManager) : base(context)
        {
            _dbContext = context;
            _roleManager = roleManager;
        }
        public Task<Role> InsertAsync(Role entity)
        {
            _roleManager.CreateAsync(entity).Wait();
            return Task.FromResult(entity);
        }
    }
}
