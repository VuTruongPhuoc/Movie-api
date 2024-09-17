using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Tracks
{
    public class GetTracksQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
