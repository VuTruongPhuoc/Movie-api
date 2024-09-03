using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Data.Configuration
{
    public class TrackConfiguration : IEntityTypeConfiguration<Track> 
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder.ToTable("Tracks");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseIdentityColumn();


        }
    }
}
