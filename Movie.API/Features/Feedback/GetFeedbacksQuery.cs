using MediatR;
using Movie.API.Requests.Pagination;
using Movie.API.Responses;

namespace Movie.API.Features.Feedbacks
{
    public class GetFeedbacksQuery : IRequest<Response>
    { 
        public int CommentId {  get; set; }
    }
}
