namespace Movie.API.Responses.DTOs
{
    public class EpisodeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int FilmId { get; set; }
        public int SectionId { get; set; }
        public string Link { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
