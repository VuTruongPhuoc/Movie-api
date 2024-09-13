using Movie.API.Models.Domain.Entities;
using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetRoleResponse : Response
    {
        public RoleDTO Role { get; set; }
    }
    public class GetRolesResponse : Response
    {
        public List<RoleDTO> Roles { get; set; }
    }
    public class AddRoleResponse : Response
    {
        public RoleDTO Role { get; set; }
    }
    public class UpdateRoleResponse : Response
    {
        public RoleDTO Role { get; set; }
    }
    public class DeleteRoleResponse : Response
    {
        public string RoleName { get; set; }
    }
}
