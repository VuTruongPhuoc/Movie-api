using Movie.API.Models.Domain.Entities;
using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class AddRoleResponse : Respone
    {
        public RoleDTO Role { get; set; }
    }
    public class GetRolesRespone : Respone
    {
        public List<RoleDTO> Roles { get; set; }
    }
}
