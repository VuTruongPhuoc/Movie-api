using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetReviewsResponse : Response
    {
        public List<ReviewDTO> Reviews { get; set; }
    }
    public class AddReviewResponse : Response
    {
        public ReviewDTO Review { get; set; }
    }
    public class UpdateReviewResponse : Response
    {
        public ReviewDTO Review { get; set; }
    }
    public class DeleteReviewResponse : Response
    {
        public ReviewDTO Review { get; set; }
    }
}
