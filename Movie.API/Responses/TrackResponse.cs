using Movie.API.Responses.DTOs;

namespace Movie.API.Responses
{
    public class GetTracksResponse : Response
    {
        public List<TrackDTO> Tracks { get; set; }
    }
    public class AddTrackResponse : Response
    {
        public TrackDTO Track { get; set; }
    }
    public class UpdateTrackResponse : Response
    {
        public TrackDTO Track { get; set; }
    }
    public class DeleteTrackResponse : Response
    {
        public TrackDTO Track { get; set; }
    }
}
