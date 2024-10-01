using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Movie.API.Models.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Models.Domain.Entities
{
    public class User : IdentityUser
    {
        public string? DisplayName { get; set; }
        public string? Avatar { get; set; }
        public string? AvatarUrl { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiry { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
