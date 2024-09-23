using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Users;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IMediator _mediator;
        
        public UserController(ILogger<UserController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("all")]
        public async Task<Response> GetUsers(int pageNumber = 1, int pageSize = 10)
        {
            var query = new GetUsersQuery()
            {
                Pagination = new Pagination()
                {
                    pageNumber = pageNumber,
                    pageSize = pageSize
                }
            };
            return await _mediator.Send(query);
        }
        [HttpPost("changerole/{username}/{role}")]        
        public async Task<IActionResult> ChangeRole(string username, string role)
        {
            var command = new ChangeRoleCommand()
            {
                UserName = username,
                RoleName = role
            };
            var response =  await _mediator.Send(command);
            if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("add")]
        public async Task<Response> Add([FromBody] AddUserRequest model)
        {
            var command = new AddUserCommand();
            CustomMapper.Mapper.Map<AddUserRequest, AddUserCommand>(model,command);
            return await _mediator.Send(command);
        }
        [HttpPost("update/{username}")]
        public async Task<Response> Update(string username,[FromBody] UpdateUserRequest model)
        {
            var command = new UpdateUserCommand();
            command.UserName = username;
            CustomMapper.Mapper.Map<UpdateUserRequest, UpdateUserCommand>(model,command);
            return await _mediator.Send(command);
        }
        [HttpDelete("delete/{username}")]
        public async Task<Response> Delete(string username)
        {
            var command = new DeleteUserCommand();
            command.UserName = username;
            return await _mediator.Send(command);
        }
    }
}
