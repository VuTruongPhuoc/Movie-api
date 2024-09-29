using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class LoginRespone : Response
    {
        public string AccessToken {  get; set; }
        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
        public UserDTO User { get; set; }
    }
    public class RegisterResponse : Response { }
    public class RefreshTokenRespone : Response { }
    
}
