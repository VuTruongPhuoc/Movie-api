using MediatR;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Features.Countries
{
    public class GetCountriesQuery :  IRequest<Response>
    {
    }
}
