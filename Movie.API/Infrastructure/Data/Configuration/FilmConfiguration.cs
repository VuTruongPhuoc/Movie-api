using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Films");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(2000);
            builder.Property(x => x.Image).HasMaxLength(255);
            builder.Property(x => x.Year).IsRequired().HasMaxLength(10);
            builder.Property(x => x.OriginName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Time).IsRequired().HasMaxLength(50);


            builder.HasOne(x => x.Country)
                .WithMany(x => x.Films)
                .HasForeignKey(x => x.CountryId);
            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.Films)
                .HasForeignKey(x => x.ScheduleId);
        }
    }
}
