using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("Histories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Histories)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Film)
                .WithMany(x => x.Histories)
                .HasForeignKey(x => x.FilmId);
        }
    }
}
