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
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, AddRoleResponse>
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly MovieDbContext _dbContext;
        private readonly IRoleRepository _roleRepository;
        public AddRoleCommandHandler(MovieDbContext dbContext,IRoleRepository roleRepository, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }
        public async Task<AddRoleResponse> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                Name = request.Role.Name,
            };
            if(await _roleManager.FindByNameAsync(role.Name) != null)
            {
                return await Task.FromResult(new AddRoleResponse
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Role đã tồn tại",
                    Role = request.Role
                });
            }
             await _roleRepository.AddAsync(role);
             await _roleRepository.SaveAsync();
            return await Task.FromResult( new AddRoleResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thêm role thành công",
                Role = request.Role
            });
        }
    }
}
