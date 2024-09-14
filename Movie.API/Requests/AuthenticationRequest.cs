using System.ComponentModel.DataAnnotations;

namespace Movie.API.Requests
{

    public class LoginRequest
    {
        public string Username { get; set;}
      
        public string Password { get; set;}

    }
    public class RegisterRequest
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }   

    }
    public class RefreshTokenRequest
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
