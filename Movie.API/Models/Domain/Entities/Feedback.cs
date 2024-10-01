using Movie.API.Models.Domain.Common;

namespace Movie.API.Models.Domain.Entities
{
    public class Feedback : BaseDomainEntity
    {
        public int CommentId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public bool IsLocked { get; set; }
        public User? User { get; set; }
        public Comment? Comment { get; set; }
    }
}
