namespace Movie.API.Models.Domain.Entities
{
    public class EpisodeServer
    {
        public int EpisodeId { get; set; }
        public int ServerId { get; set; }
        public Episode? Episode { get; set; }
        public Server? Server { get; set; }
    }
}
