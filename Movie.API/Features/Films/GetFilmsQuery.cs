using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Films
{
    public class GetFilmsQuery : IRequest<Response>
    {
    }
}
