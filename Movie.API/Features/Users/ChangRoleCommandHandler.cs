using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;

namespace Movie.API.Features.Users
{
    public class ChangRoleCommandHandler : IRequestHandler<ChangeRoleCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<Role> _roleManager;
        public ChangRoleCommandHandler(IUserRepository userRepository, RoleManager<Role> roleManager)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
        }
        public async Task<Response> Handle(ChangeRoleCommand request, CancellationToken cancellationToken)
        {
            var roleExists = await _roleManager.FindByNameAsync(request.RoleName);
            if(roleExists is null)
            {
                return await Task.FromResult(new Response()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tồn tại role cần cập nhật"
                });
            }
            await _userRepository.ChangeRoleAsync(request.UserName, request.RoleName);
            await _userRepository.SaveAsync();
            return await Task.FromResult(new Response()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Thành công hihi"
            });
        }
    }
}
