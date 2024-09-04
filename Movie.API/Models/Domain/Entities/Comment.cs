using Movie.API.Models.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Models.Domain.Entities
{
    public class Comment : BaseDomainEntity
    {
        public int UserId { get; set; }
        public int FilmId {  get; set; }
        public string content { get; set; } = default!;
        public bool IsLocked { get; set; }
        public User User { get; set; }
        public Film Film { get; set; }
    }
}
