using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Countries
{
    public class AddCountryCommand : AddCountryRequest, IRequest<Response>
    {
    }
}
