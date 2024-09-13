using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;
using System.Data;

namespace Movie.API.Features.Roles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, DataRespone>
    {
        private readonly MovieDbContext _dbContext;
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<Role> _roleManager;
        public GetRolesQueryHandler(MovieDbContext dbContext,IRoleRepository roleRepository, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }
        public async Task<DataRespone> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllAsync();
            var dtos = CustomMapper.Mapper.Map<List<RoleDTO>>(roles);

            return await Task.FromResult(new DataRespone()
            {
                Success = true,
                Message = "ok",
                StatusCode = System.Net.HttpStatusCode.OK,
                Data = dtos
            });
        }
    }
}
