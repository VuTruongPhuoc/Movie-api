namespace Movie.API.Requests
{
    public class AddTrackRequest
    {
        public string UserId { get; set; }
        public int FilmId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class DeleteTrackRequest
    {

    }
}
