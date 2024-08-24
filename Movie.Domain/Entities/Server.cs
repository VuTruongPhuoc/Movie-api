using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Server : BaseDomainEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; } 
    }
}
