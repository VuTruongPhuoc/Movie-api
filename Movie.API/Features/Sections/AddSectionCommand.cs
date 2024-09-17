using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Sections
{
    public class AddSectionCommand : AddSectionRequest, IRequest<Response>
    {
    }
}
