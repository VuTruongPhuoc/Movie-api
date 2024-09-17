namespace Movie.API.Responses.DTOs
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FilmId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
