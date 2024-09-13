namespace Movie.API.Responses
{
    public class LoginRespone : Response
    {
        public string Username { get; set; }
        public string AccessToken {  get; set; }

        public DateTime Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
    public class RefreshTokenRespone : Response { }
    
}
