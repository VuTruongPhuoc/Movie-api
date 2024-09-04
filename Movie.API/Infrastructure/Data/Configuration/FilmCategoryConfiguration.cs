using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class FilmCategoryConfiguration : IEntityTypeConfiguration<FilmCategory>
    {
        public void Configure(EntityTypeBuilder<FilmCategory> builder)
        {
            builder.HasKey(x => new { x.FilmId, x.CategoryId });
        }
    }
}
