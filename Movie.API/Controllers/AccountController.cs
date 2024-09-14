using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Models.Domain.Entities;
using Movie.API.Requests;
using Movie.API.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movie.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly UserManager<User> _userManager;
        public readonly IConfiguration _configuration;
        private readonly AccountManager _accountManager;
        public AccountController(UserManager<User> userManager,IConfiguration configuration, AccountManager accountManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _accountManager = accountManager;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<Response> Login([FromBody] LoginRequest model)
        {
            return await _accountManager.LoginAsync(model);
        }
        [HttpPost("register")]
        public async Task<Response> Register([FromBody] RegisterRequest model)
        {
            return await _accountManager.RegisterAsync(model);
        }
        [HttpPost("refreshtoken")]
        public async Task<Response> Refresh([FromBody] RefreshTokenRequest model)
        {
            return await _accountManager.RefreshToken(model);
        }
        [HttpDelete("revoketoken")]
        public async Task<Response> Revoke()
        {
            string username = HttpContext.User.Identity.Name;
            return await _accountManager.Revoke(username);
        }
        
        
    }
}
