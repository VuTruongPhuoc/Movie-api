using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Movie.API.Infrastructure.Repositories;
using Movie.API.Requests;
using Movie.API.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer",Roles = "Admin")]
    public class AccountController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        private readonly AccountManager _accountManager;
        public AccountController(IConfiguration configuration, AccountManager accountManager)
        {
            _configuration = configuration;
            _accountManager = accountManager;
        }
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide username and password");

            }
            var responeLogin = new AuthenticationResponse();
            if (model.Username == "phuoc" &&  model.Password == "123")
            {
                var claims = new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Username),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim(ClaimTypes.MobilePhone, "0233294832")
                    };
                var token = _accountManager.GetToken(claims);
                var jwttoken = new JwtSecurityTokenHandler().WriteToken(token);
                responeLogin = new AuthenticationResponse()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Success = true,
                    Message = "Đăng nhập thành công",
                    token = jwttoken,
                    Username = model.Username,
                };
            }
            else
            {
                return Ok("Invalid username or password");
            }
            return Ok(responeLogin);
        }
        
        
    }
}
