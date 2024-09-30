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
        public string Slug { get; set; }
        public string Description { get; set; } = default!;
        public string? Image { get; set; }

        [Column("number_of_episodes")]
        public int NumberOfEpisodes {  get; set; }
        public string OriginName { get; set; }
        public string Time {  get; set; }
        public int Year { get; set; }
        public int Type { get; set; }
        public string? Trailer { get; set; }
        public int CountryId { get; set; }
        public int ScheduleId { get; set; }
        public Country? Country { get; set; }
        public Schedule? Schedule { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; } 
        public virtual ICollection<Review> Reviews { get; set; } 
        public virtual ICollection<Track> Tracks { get; set; } 
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; }

    }
}
