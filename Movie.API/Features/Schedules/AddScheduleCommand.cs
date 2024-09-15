using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Schedules
{
    public class AddScheduleCommand : AddScheduleRequest, IRequest<Response>
    {
    }
}
