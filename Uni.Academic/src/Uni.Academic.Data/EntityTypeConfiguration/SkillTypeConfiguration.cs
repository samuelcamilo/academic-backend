using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Infrastructure.EntityTypeConfiguration
{
    class SkillTypeConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            
            builder.ToTable("Skills");

            builder.ApplyDefaultConfig();
        }
    }
}
