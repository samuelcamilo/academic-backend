using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Infrastructure.EntityTypeConfiguration
{
    public class HobbieTypeConfiguration : IEntityTypeConfiguration<Hobbie>
    {
        public void Configure(EntityTypeBuilder<Hobbie> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100);

            builder.ToTable("Hobbies");

            builder.ApplyDefaultConfig();
        }
    }
}
