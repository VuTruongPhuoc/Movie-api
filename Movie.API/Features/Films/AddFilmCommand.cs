using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Films
{
    public class AddFilmCommand : AddFilmRequest, IRequest<Response>
    {
    }
}
