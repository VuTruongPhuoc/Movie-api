using Movie.API.Models.Domain.Entities;
using System.Text.Json.Serialization;

namespace Movie.API.Responses.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string UserId { get; set; }
        [JsonIgnore]
        public string FilmId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public UserDTO User { get; set; }
        public List<FeedbackDTO> Feedbacks { get; set; }
        
    }
}
