using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class SubjecUsersTypeConfiguration : IEntityTypeConfiguration<SubjectUsers>
    {
        public void Configure(EntityTypeBuilder<SubjectUsers> builder)
        {
            builder.HasKey(x => new { x.SubjectId, x.StudentId });

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.SubjectStudents)
                .IsRequired()
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Student)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("SubjecUsers");
        }
    }
}
