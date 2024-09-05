namespace Movie.API.Responses.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string Image { get; set; }
        public int ReleaseYear { get; set; }
    }
}
