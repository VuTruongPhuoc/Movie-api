using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Data;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Common;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Users
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, DataRespone>
    {
        private readonly MovieDbContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<Role> _roleManager;
        public GetUsersQueryHandler(MovieDbContext dbContext,IUserRepository userRepository, RoleManager<Role> roleManager)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _roleManager = roleManager;
        }
        public async Task<DataRespone> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(request.Pagination.pageNumber, request.Pagination.pageSize);
            var userdtos = new List<UserDTO>();

            foreach (var user in users.Items)
            {
                var userRole = await _dbContext.UserRoles.SingleOrDefaultAsync(x => x.UserId == user.Id);
                if (userRole != null)
                {
                    var role = await _roleManager.FindByIdAsync(userRole.RoleId);
                    if (role != null)
                    {
                        var userDto = CustomMapper.Mapper.Map<User, UserDTO>(user);
                        userDto.RoleName = role.Name ?? "Cùi bắp";
                        
                        userdtos.Add(userDto);
                    }
                }
            }
            var dtos = CustomMapper.Mapper.Map<PaginatedList<UserDTO>>(users);
            dtos.Items = userdtos;
            return new DataRespone
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công",
                Data = dtos
            };
        }
    }
}
