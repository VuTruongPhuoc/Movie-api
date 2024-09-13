using MediatR;
using Movie.API.Responses;
using Movie.API.Responses.DTOs;

namespace Movie.API.Features.Roles
{
    public class UpdateRoleCommand : UpdateRoleResponse, IRequest<UpdateRoleResponse>
    {
    }
}
