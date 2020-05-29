using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Infrastructure.EntityTypeConfiguration
{
    public class QualificationTypeConfiguration : IEntityTypeConfiguration<Qualification>
    {
        public void Configure(EntityTypeBuilder<Qualification> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Resume).HasMaxLength(255);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.FinishedDate).IsRequired();

            builder.ToTable("Qualifications");

            builder.ApplyDefaultConfig();
        }
    }
}
