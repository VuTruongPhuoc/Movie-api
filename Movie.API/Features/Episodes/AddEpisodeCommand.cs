using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Episodes
{
    public class AddEpisodeCommand : AddEpisodeRequest, IRequest<Response>
    {
    }
}
