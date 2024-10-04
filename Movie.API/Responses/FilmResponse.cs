using Movie.API.Models.Domain.Common;
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
    public class FilmPosterResponse : Response
    {
        public FilmPoster Film { get; set; }
    }
    public class GetFilmBySlugResponse : Response
    {
        public FilmDTO Film { get; set; }
        public List<EpisodeDTO> Episodes { get; set;}
    }

    public class FilterFilmResponse : Response
    {
        public string Name {  get; set; }
        public PaginatedList<FilmFilter> Data { get; set; }
    }
}
