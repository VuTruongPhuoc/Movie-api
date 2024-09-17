using MediatR;
using Movie.API.Responses;

namespace Movie.API.Features.Comments
{
    public class GetCommentsQuery : IRequest<Response>
    { 
        public int FilmId {  get; set; }
    }
}
