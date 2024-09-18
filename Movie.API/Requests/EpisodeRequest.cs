namespace Movie.API.Requests
{
    public class AddEpisodeRequest
    {
        public string Name { get; set; }
        public int FilmId { get; set; }
        public int SectionId { get; set; }
        public string Link { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class UpdateEpisodeRequest
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
    public class DeleteEpisodeRequest
    {

    }
}
