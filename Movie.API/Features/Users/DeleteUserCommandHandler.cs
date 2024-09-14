using MediatR;
using Microsoft.AspNetCore.Identity;
using Movie.API.AutoMapper;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Users
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(UserManager<User> userManager, IUserRepository userRepository)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user is null)
            {
                return await Task.FromResult(new DeleteUserResponse()
                {
                    Success = false,
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    Message = "Không tìm thấy user"
                    
                });
            }
            await _userRepository.DeleteUserAsync(request.UserName);          
            await _userRepository.SaveAsync();
            return await Task.FromResult(new DeleteUserResponse()
            {
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                Message = "Xóa user thành công",
                User = CustomMapper.Mapper.Map<UserDTO>(user)
            });
        }
    }
}
