using MediatR;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Features.Comments
{
    public class GetCommentsQuery : IRequest<DataRespone>
    { 
        public int FilmId {  get; set; }
    }
}
