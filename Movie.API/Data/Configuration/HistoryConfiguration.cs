﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Movie.API.Models.Domain.Entities;

namespace Movie.API.Data.Configuration
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.ToTable("Histories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

        }
    }
}
