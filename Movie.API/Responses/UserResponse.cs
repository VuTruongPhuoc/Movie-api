using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetUsersResponse : Response
    {
        public List<UserDTO> Users { get; set; }
    }
    public class AddUserResponse : Response
    {
        public UserDTO User { get; set; }
    }
    public class UpdateUserResponse : Response
    {
        public UserDTO User { get; set; }
    }
    public class UserAvatarResponse : Response
    {
        public UserAvatar User { get; set; }
    }
    public class DeleteUserResponse : Response
    {
        public UserDTO User { get; set; }
    }
}
