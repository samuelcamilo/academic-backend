using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class SubjectTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Code).HasMaxLength(7);

            builder.HasOne(x => x.Teacher)
                .WithMany()
                .HasForeignKey(x => x.TeacherId);

            builder.Property(x => x.Period).HasMaxLength(20);
        }
    }
}
