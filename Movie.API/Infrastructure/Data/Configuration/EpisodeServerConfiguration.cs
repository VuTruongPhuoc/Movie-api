using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class EpisodeServerConfiguration : IEntityTypeConfiguration<EpisodeServer>
    {
        public void Configure(EntityTypeBuilder<EpisodeServer> builder)
        {
            builder.ToTable("EpisodeServers");
            builder.HasKey(x => new { x.ServerId, x.EpisodeId });
        }
    }
}
