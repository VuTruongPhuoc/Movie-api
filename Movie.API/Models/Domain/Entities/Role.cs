using Microsoft.AspNetCore.Identity;
using Movie.API.Models.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Models.Domain.Entities
{
    public class Role : IdentityRole
    {
        public virtual ICollection<RolePrivileges> RolePrivileges { get; set; }
    }
}
