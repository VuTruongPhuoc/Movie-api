﻿using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Country: BaseDomainEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public List<Film> Films { get; set; } = new();
    }
}
