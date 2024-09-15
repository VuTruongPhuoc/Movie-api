using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Schedules
{
    public class GetSchedulesQuery : GetSchedulesResponse, IRequest<Response>
    { 
    }
}
