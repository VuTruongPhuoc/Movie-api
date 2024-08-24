﻿using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Review: BaseDomainEntity
    {
        public int UserId { get; set; }
        public int FilmId {  get; set; }
        public int Rate { get; set; }
        public Film? Film { get; set; }
        public User? User { get; set; }
    }
}
