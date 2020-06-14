using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Commons;

namespace Uni.Academic.Data.EntityTypeConfiguration
{
    public static class EntityTypeBuilderExtension
    {
        public static void ApplyDefaultConfig<T>(this EntityTypeBuilder<T> builder)
            where T : Entity => builder.HasKey(i => i.Id);
    }
}
