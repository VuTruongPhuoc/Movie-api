using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Countries
{
    public class GetCountriesQuery : GetCountriesResponse, IRequest<Response>
    { 
    }
}
