using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Models.Domain.Entities
{
    public class History
    {
        public int UserId { get; set; }

        public User? User { get; set; }

        public List<Film> Films { get; set; } = new();
    }
}
