using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Users
{
    public class GetUsersQuery : IRequest<Response>
    {
    }
}
