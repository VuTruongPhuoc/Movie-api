using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Movie.API.Requests;
using Movie.API.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Movie.API.Infrastructure.Repositories
{
    //public interface IAccountRepository
    //{
    //    Task<AuthenticationResponse> LoginAsync(LoginRequest model);
    //}
    public class AccountManager
    {
        private readonly IConfiguration _configuration;
        public AccountManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<AuthenticationResponse> LoginAsync(LoginRequest model)
        {
            return new AuthenticationResponse()
            {
                Username = model.Username,
                
                Success = true,
                StatusCode = System.Net.HttpStatusCode.OK,
                token = "23423423",
            };
        }
        public JwtSecurityToken GetToken(IEnumerable<Claim> claims)
        {
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetValue<string>("JWTSecret")));
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = _configuration["LocalIssuer"],
                Audience = _configuration["LocalAudience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return token;
        }

    }
}
