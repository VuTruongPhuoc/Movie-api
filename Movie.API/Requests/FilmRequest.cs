namespace Movie.API.Requests
{
    public class AddFilmRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int ReleaseYear {  get; set; }
        public int CountryId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
    public class UpdateFilmRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int ReleaseYear { get; set; }
        public int CountryId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; }
    }
    public class DeleteFilmRequest
    {

    }
}
