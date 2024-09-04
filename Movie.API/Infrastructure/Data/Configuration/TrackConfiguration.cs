using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Tracks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();

            builder.HasOne(t => t.Film)
                .WithMany(t => t.Tracks)
                .HasForeignKey(t => t.FilmId);
            builder.HasOne(t => t.User)
                .WithMany(t => t.Tracks)
                .HasForeignKey(t => t.UserId);
        }
    }
}
