using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Infrastructure.EntityTypeConfiguration
{
    class MaterialTypeConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(50);
            builder.Property(x => x.FileBase64).HasColumnType("varchar(max)").IsRequired();

            builder.ToTable("Materials");

            builder.ApplyDefaultConfig();
        }
    }
}
