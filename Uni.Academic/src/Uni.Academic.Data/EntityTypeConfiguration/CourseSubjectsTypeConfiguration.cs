using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class CourseSubjectsTypeConfiguration : IEntityTypeConfiguration<CourseSubjects>
    {
        public void Configure(EntityTypeBuilder<CourseSubjects> builder)
        {
            builder.HasKey(pk => new { pk.CourseId, pk.SubjectId });
            
            builder.HasOne(x => x.Course)
                .WithMany(x => x.CourseSubjects)
                .IsRequired()
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Subject)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("CourseSubjects");
        }
    }
}
