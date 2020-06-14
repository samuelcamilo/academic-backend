using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Models;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public class SubjectMaterialsTypeConfiguration : IEntityTypeConfiguration<SubjectMaterials>
    {
        public void Configure(EntityTypeBuilder<SubjectMaterials> builder)
        {
            builder.HasKey(pk => new { pk.SubjectId, pk.MaterialId });

            builder.HasOne(x => x.Subject)
                .WithMany(x => x.SubjectMaterials)
                .IsRequired()
                .HasForeignKey(x => x.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Material)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.MaterialId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("SubjectMaterials");
        }
    }
}
