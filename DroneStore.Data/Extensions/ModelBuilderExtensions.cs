using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DroneStore.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static PropertyBuilder<decimal> HasPrecision(
            this PropertyBuilder<decimal> builder, int precision, int scale) =>
            builder.HasColumnType($"decimal({precision},{scale})");

        public static PropertyBuilder<decimal?> HasPrecision(
            this PropertyBuilder<decimal?> builder, int precision, int scale) =>
            builder.HasColumnType($"decimal({precision},{scale})");
    }
}
