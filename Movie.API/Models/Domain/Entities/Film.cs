using Movie.API.Models.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Models.Domain.Entities
{
    public class Film : BaseDomainEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? Image { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int ReleaseYear { get; set; }
        public int CountryId { get; set; }
        public int ScheduleId { get; set; }
        public Country? Country { get; set; }
        public Schedule? Schedule { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; } 
        public virtual ICollection<Review> Reviews { get; set; } 
        public virtual ICollection<Track> Tracks { get; set; } 
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<History> Histories { get; set; }

    }
}
