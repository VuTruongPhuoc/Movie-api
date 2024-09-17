namespace Movie.API.Requests
{
    public class AddReviewRequest
    {
        
        public int FilmId { get; set; }
        public int Rate { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class DeleteReviewRequest
    {

    }
}
