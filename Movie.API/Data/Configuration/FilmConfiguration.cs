using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Data.Configuration
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x =>x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x =>x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x =>x.Image).IsRequired().HasMaxLength(255);
            builder.Property(x =>x.NumberOfEpisodes).IsRequired().HasMaxLength(10);
            builder.Property(x =>x.ReleaseYear).IsRequired().HasMaxLength(10);
        }
    }
}
