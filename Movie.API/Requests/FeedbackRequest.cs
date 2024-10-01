namespace Movie.API.Requests
{
    public class AddFeedbackRequest
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class UpdateFeedbackRequest
    {
        public string Content { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
    public class DeleteFeedbackRequest
    {

    }
}
