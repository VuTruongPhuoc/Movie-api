using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Histories
{
    public class GetHistoriesQuery : IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
