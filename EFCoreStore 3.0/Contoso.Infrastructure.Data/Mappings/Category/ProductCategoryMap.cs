using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class ProductCategoryMap : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            //多对多关系
            builder.ToTable("Product_Category_Mapping");

            //builder.HasKey(pc => pc.Id);

            builder.Ignore(pc => pc.Id);
            builder.HasKey(pc => new { pc.CategoryId, pc.ProductId });

            //builder.Property(pc => pc.IsFeaturedProduct)
            //       .HasColumnName("IsFeaturedProduct");

            //builder.Property(pc => pc.DisplayOrder)
            //       .HasColumnName("DisplayOrder");

            //builder.Property(pc => pc.CategoryId)
            //        .HasColumnName("CategoryId");

            //builder.Property(pc => pc.ProductId)
            //       .HasColumnName("ProductId");

            builder.HasOne(pc => pc.Category)
                   .WithMany(c => c.ProductCategories)
                   .HasForeignKey(pc => pc.CategoryId)
                   .IsRequired();

            builder.HasOne(pc => pc.Product)
                   .WithMany(c => c.ProductCategories)
                   .HasForeignKey(pc => pc.ProductId)
                   .IsRequired();
        }
    }
}
