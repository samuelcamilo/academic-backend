using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class UserQualificationsTypeConfiguration : IEntityTypeConfiguration<UserQualifications>
    {
        public void Configure(EntityTypeBuilder<UserQualifications> builder)
        {
            builder.HasKey(pk => new { pk.UserId, pk.QualificationId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserQualifications)
                .IsRequired()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Qualification)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.QualificationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserQualifications");
        }
    }
}
