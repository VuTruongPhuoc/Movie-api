using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class EpisodeConfiguration : IEntityTypeConfiguration<Episode>
    {
        public void Configure(EntityTypeBuilder<Episode> builder)
        {
            builder.ToTable("Episodes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(50);
            builder.HasOne(x => x.Film)
                .WithMany(x => x.Episodes)
                .HasForeignKey(x => x.FilmId);
            builder.HasOne(x => x.Section)
                .WithMany(x => x.Episodes)
                .HasForeignKey(x => x.SectionId);
        }
    }
}
