using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Episodes
{
    public class GetEpisodesQuery : IRequest<Response>
    {
        public int FilmId { get; set; }
    }
}
