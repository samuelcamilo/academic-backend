using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class UserHobbiesTypeConfiguration : IEntityTypeConfiguration<UserHobbies>
    {
        public void Configure(EntityTypeBuilder<UserHobbies> builder)
        {
            builder.HasKey(pk => new { pk.UserId, pk.HobbieId });

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserHobbies)
                .IsRequired()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Hobbie)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.HobbieId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("UserHobbies");
        }
    }
}
