using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Roles
{
    public class InsertRoleCommandHandler : IRequestHandler<InsertRoleCommand, Respone>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly MovieDbContext _dbContext;
        private readonly IRoleRepository _roleRepository;
        public InsertRoleCommandHandler(MovieDbContext dbContext,IRoleRepository roleRepository, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }
        public async Task<Respone> Handle(InsertRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                Name = request.Role.Name,
            };
            await _roleRepository.InsertAsync(role);
            await _dbContext.SaveChangesAsync();
            return new AddRoleResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm role thành công",
                Role = request.Role
            };
        }
    }
}
