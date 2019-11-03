using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));

            builder.HasKey(product => product.Id);

            builder.Property(p => p.Name)
                   .HasMaxLength(2048)
                   .IsRequired();

            builder.Property(p => p.Alias)
                   .HasMaxLength(1024);

            builder.Property(p => p.Code)
                   .HasMaxLength(512);

            builder.Property(p => p.Sku)
                   .HasMaxLength(1024);

            builder.Property(p => p.Price)
                   .HasColumnType("money");
            builder.Property(p => p.OldPrice)
                   .HasColumnType("money");
            builder.Property(p => p.ProductCost)
                   .HasColumnType("money");

            //builder.Property(p => p.SpecialPrice)
            //       .HasColumnType("money");
            //builder.Property(p => p.SpecialPriceStartDateTimeUtc)
            //   .HasColumnType("datetime2");
            //builder.Property(p => p.SpecialPriceEndDateTimeUtc)
            //       .HasColumnType("datetime2");

            builder.Property(p => p.MarkAsNewStartDateTimeUtc)
                   .HasColumnType("datetime2");
            builder.Property(p => p.MarkAsNewEndDateTimeUtc)
                   .HasColumnType("datetime2");

            builder.Property(p => p.AvailableStartDateTimeUtc)
              .HasColumnType("datetime2");
            builder.Property(p => p.AvailableEndDateTimeUtc)
                   .HasColumnType("datetime2");

            //unique,唯一约束
            builder.HasAlternateKey(p => p.Name);

            //unique,唯一约束
            builder.HasAlternateKey(p => p.Code);

            //缺省
            //builder.Property(p => p.Published)
            //       .HasDefaultValue(true);

            //缺省日期
            builder.Property(p => p.CreatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            builder.Property(p => p.UpdatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            //一对多关系的自引用
            builder.HasMany(p => p.SubProducts)
                   .WithOne(p => p.Parent)
                   .HasForeignKey(p => p.ParentId);
        }
    }
}
