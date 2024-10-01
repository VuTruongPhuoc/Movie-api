using MediatR;
using Movie.API.Requests;
using Movie.API.Responses;

namespace Movie.API.Features.Feedbacks
{
    public class AddFeedbackCommand : AddCommentRequest, IRequest<Response>
    {
        public string UserId { get; set; }
    }
}
