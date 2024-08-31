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
        public string Image { get; set; } = default!;
        public int NumberOfEpisodes { get; set; }
        public int ReleaseYear { get; set; }
        public long ViewCount { get; set; }
        public int CountryId { get; set; }
        public int HistoryId { get; set; }
        public int ScheduleId { get; set; }
        public Country? Country { get; set; }
        public History? History { get; set; }
        public Schedule? Schedule { get; set; }
        public List<Episode> Episodes { get; set; } = new();
        public List<Section> Sections { get; set; } = new();
        public List<Category> Categories { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public List<Track> Tracks { get; set; } = new();

    }
}
