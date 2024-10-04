using System.Text.Json.Serialization;

namespace Movie.API.Responses.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }
        [JsonIgnore]
        public string UserId { get; set; }
        [JsonIgnore]
        public string CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public UserDTO User { get; set; }
    }
}
