using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movie.API.AutoMapper;
using Movie.API.Features.Roles;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _imediator;
        private readonly ILogger<RoleController> _logger;
        private readonly RoleManager<Role> _roleManager;
        public RoleController(IMediator imediator, ILogger<RoleController> logger, RoleManager<Role> roleManager)
        {
            _imediator = imediator;
            _logger = logger;
            _roleManager = roleManager;
        }

        [HttpGet("getall")]
        public async Task<Response> GetRoles()
        {
            var query = new GetRolesQuery();

            return await _imediator.Send(query);
        }
        [HttpPost("add")]
        public async Task<Response> AddRole([FromBody] RoleDTO role)
        {
            return await _imediator.Send(new AddRoleCommand()
            {
                Role = role
            });
        }
        [HttpPost("update")]
        public async Task<Response> UpdateRole([FromBody] RoleDTO role)
        {
            return await _imediator.Send(new UpdateRoleCommand()
            {
                Role = role
            });
        }
        [HttpDelete("delete")]
        public async Task<Response> DeleteRole(string rolename)
        {

            return await _imediator.Send(new DeleteRoleCommand()
            {
               RoleName = rolename
            });
        }
    }
}
