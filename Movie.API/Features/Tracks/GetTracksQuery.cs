using MediatR;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Features.Tracks
{
    public class GetTracksQuery : IRequest<Response>
    {
        public Pagination Pagination { get; set; }
        public string UserId { get; set; }
    }
}
