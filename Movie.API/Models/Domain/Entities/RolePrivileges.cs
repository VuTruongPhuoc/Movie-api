using Movie.API.Models.Domain.Common;

namespace Movie.API.Models.Domain.Entities
{
    public class RolePrivileges: BaseDomainEntity
    {
        public int RoleId { get; set; }

        public string RolePrivilegeName { get; set; } = default!;

    }
}
