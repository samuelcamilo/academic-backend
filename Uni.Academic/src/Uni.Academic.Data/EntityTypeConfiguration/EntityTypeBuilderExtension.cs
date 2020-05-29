using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Uni.Academic.Core.Commons;

namespace Uni.Academic.Infrastructure.EntityTypeConfiguration
{
    public static class EntityTypeBuilderExtension
    {
        public static void ApplyDefaultConfig<T>(this EntityTypeBuilder<T> buider)
            where T : Entity => buider.HasKey(i => i.Id);
    }
}
