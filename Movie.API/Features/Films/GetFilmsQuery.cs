using MediatR;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Features.Films
{
    public class GetFilmsQuery : IRequest<Response>
    { 
        public Pagination Pagination { get; set; } = new Pagination();
    }
}
