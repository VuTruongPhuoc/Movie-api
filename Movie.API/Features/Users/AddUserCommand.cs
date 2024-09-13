using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Users
{
    public class AddUserCommand : AddUserRequest, IRequest<AddUserResponse>
    {
    }
}
