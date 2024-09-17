namespace Movie.API.Requests
{
    public class AddCommentRequest
    {    
        public int FilmId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class UpdateCommentRequest
    {
        public string Content { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
    public class DeleteCommentRequest
    {

    }
}
