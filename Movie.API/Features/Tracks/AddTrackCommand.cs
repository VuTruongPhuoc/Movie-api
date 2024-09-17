using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Tracks
{
    public class AddTrackCommand : AddTrackRequest, IRequest<Response>
    {
    }
}
