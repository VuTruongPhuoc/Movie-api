using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Data.Configuration
{
    public class RolePrivilegesConfiguration : IEntityTypeConfiguration<RolePrivileges>
    {
        public void Configure(EntityTypeBuilder<RolePrivileges> builder)
        {
            builder.ToTable("RolePrivileges");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
        }
    }
}
