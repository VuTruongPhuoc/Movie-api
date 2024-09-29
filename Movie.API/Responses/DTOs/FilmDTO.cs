namespace Movie.API.Responses.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Slug { get; set; }
        public string Description { get; set; } 
        public string? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string OriginName { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public List<CategoryDTO> Categories { get; set; }
        public CountryDTO Country { get; set; }
        public ScheduleDTO Schedule {  get; set; }
        public DateTime CreateDate {  get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive {  get; set; }
    }
    public class FilmImage
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? ImageUrl { get; set; }

    }
}
