using Movie.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Entities
{
    public class Comment: BaseDomainEntity
    {
        public int UserId { get; set; }
        public string content { get; set; } = default!;
        public bool IsLocked { get; set; }
        public User? User { get; set; }
    }
}
