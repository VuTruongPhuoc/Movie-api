using System.ComponentModel.DataAnnotations.Schema;

namespace Movie.API.Requests
{
    public class ChangeRoleRequest
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }  
    }
    public class AddUserRequest
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
    public class UpdateUserRequest
    {
        public string DisplayName { get; set;}
        public string Email { get; set;}
        public string? PhoneNumber { get; set;}  
    }
    public class ChangeImageRequest
    {
        public string UserName { get; set; }
        [NotMapped]
        public IFormFile AvatarFile { get; set;}
    }
    public class DeleteUserRequest
    {
    }
}
