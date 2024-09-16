namespace Movie.API.Responses.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string? Image { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int ReleaseYear { get; set; }
        public int CountryId { get; set; }
        public int ScheduleId {  get; set; }
        public DateTime CreateDate {  get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive {  get; set; }
    }
}
