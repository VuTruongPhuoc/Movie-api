using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Users;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMediator _mediator;
        
        public UserController(ILogger<UserController> logger,UserManager<User> userManager, RoleManager<Role> roleManager, IMediator mediator)
        {
            _logger = logger;
            _userManager = userManager; 
            _roleManager = roleManager;
            _mediator = mediator;
        }

        [HttpPost("add")]
        public async Task<Response> Add([FromBody] AddUserRequest model)
        {
            var command = new AddUserCommand();
            CustomMapper.Mapper.Map<AddUserRequest, AddUserCommand>(model,command);
            return await _mediator.Send(command);
        }
    }
}
