using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class UserRoleMappingConfiguration : IEntityTypeConfiguration<UserRoleMapping>
    {
        public void Configure(EntityTypeBuilder<UserRoleMapping> builder)
        {
            builder.HasKey(builder => new {builder.UserId, builder.RoleId});
        }
    }
}
