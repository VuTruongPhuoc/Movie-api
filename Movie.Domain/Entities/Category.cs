﻿using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Category : BaseDomainEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public int FilmId { get; set; }
        public List<Film> films { get; set; } = new();
    }
}
