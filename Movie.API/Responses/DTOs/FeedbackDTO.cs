namespace Movie.API.Responses.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
