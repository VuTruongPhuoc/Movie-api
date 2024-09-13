using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;

namespace Movie.API.Features.Roles
{
    public class UpdateRoleCommandHandler :  IRequestHandler<UpdateRoleCommand, UpdateRoleResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly RoleManager<Role> _roleManager;
        public UpdateRoleCommandHandler(IRoleRepository roleRepository, RoleManager<Role> roleManager)
        {
            _roleRepository = roleRepository;
            _roleManager = roleManager;
        }

        public Task<UpdateRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role
            {
                Id = request.Role.Id,
                Name = request.Role.Name,
            };
            if (_roleManager.Roles.FirstOrDefault(x => x.Id == role.Id) == null)
            {
                return Task.FromResult(new UpdateRoleResponse
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy role ",
                    Role = request.Role
                   
                });
            }
            if(_roleManager.Roles.FirstOrDefault(x => x.Name == role.Name) != null)
            {
                return Task.FromResult(new UpdateRoleResponse
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    Message = "Role đã tồn tại",
                    Role = request.Role
                });
            }
            _roleRepository.UpdateAsync(role);
            _roleRepository.SaveAsync();
            return Task.FromResult(new UpdateRoleResponse
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Cập nhật role thành công",
                Role = request.Role

            }); 
        }
    }
}
