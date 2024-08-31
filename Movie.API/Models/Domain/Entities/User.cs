using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Movie.API.Models.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.API.Models.Domain.Entities
{
    public class User :  IdentityUserToken
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? BirthDay { get; set; }
        public string? Gender { get; set; }
        public string RefreshToken { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
