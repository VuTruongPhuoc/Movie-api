﻿using Movie.API.Models.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Models.Domain.Entities
{
    public class Episode : BaseDomainEntity
    {
        public string Name { get; set; } = default!;
        public string Slug { get; set; }
        public int FilmId { get; set; }
        public int SectionId { get; set; }
        public long View { get; set; }
        public string Link { get; set; } = default!;
        public Film Film { get; set; }
        public Section Section { get; set; }
    }
}
