using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Roles
{
    public class DeleteRoleCommand : DeleteRoleResponse, IRequest<DeleteRoleResponse>
    {
    }
}
