using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class UserResponse
    {
    }
    public class AddUserResponse : Response
    {
        public UserDTO User { get; set; }
    }
}
