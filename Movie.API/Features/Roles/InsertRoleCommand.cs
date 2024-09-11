using MediatR;
using Movie.API.Models.Domain.Entities;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Roles
{
    public class InsertRoleCommand : IRequest<Respone>
    {
        public RoleDTO Role {  get; set; }
    }
}
