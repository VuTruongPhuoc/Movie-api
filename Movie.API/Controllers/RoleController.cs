using MediatR;
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
        public async Task<Respone> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            var query = new GetRolesQuery()
            {
                Roles = CustomMapper.Mapper.Map<List<RoleDTO>>(roles)
            };

            return await _imediator.Send(query);
        }
        [HttpPost("insert")]
        public async Task<Respone> InsertRole([FromBody] RoleDTO role)
        {
            return await _imediator.Send(new InsertRoleCommand()
            {
                Role = role
            });
        }
    }
}
