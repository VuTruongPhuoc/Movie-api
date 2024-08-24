using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Section : BaseDomainEntity
    {
        public string Name { get; set; }
        public int FilmId { get; set; }
        public Film? Film { get; set; }
    }
}
