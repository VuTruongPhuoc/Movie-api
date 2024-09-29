using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetFilmResponse : Response
    {
        public FilmDTO Film { get; set; }
    }
    public class GetFilmsResponse : Response
    {
        public List<FilmDTO> Films { get; set; }
    }
    public class AddFilmResponse : Response
    {
        public FilmDTO Film { get; set; }
    }
    public class UpdateFilmResponse : Response
    {
        public FilmDTO Film { get; set; }
    }
    public class DeleteFilmResponse : Response
    {
        public FilmDTO Film { get; set; }
    }
    public class FilmImageResponse : Response
    {
        public FilmImage Film { get; set; }
    }
}
