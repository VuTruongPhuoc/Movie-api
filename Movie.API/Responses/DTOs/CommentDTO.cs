namespace Movie.API.Responses.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FilmId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
