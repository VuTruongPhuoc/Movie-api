using MediatR;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Features.Sections
{
    public class GetSectionsQuery : IRequest<Response>
    {
        public Pagination Pagination ;
    }
}
