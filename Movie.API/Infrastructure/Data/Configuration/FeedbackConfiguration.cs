using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Infrastructure.Data.Configuration
{
    public class FeedbackConfiguration : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(255);


            builder.HasOne(x => x.User)
                .WithMany(x => x.Feedbacks)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Comment)
                .WithMany(x => x.Feedbacks)
                .HasForeignKey(x => x.CommentId);

               
        }
    }
}
