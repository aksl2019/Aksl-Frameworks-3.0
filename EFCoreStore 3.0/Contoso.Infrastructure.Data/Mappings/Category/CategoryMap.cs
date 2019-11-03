using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

//https://www.cnblogs.com/VolcanoCloud/p/4487504.html

namespace Contoso.Infrastructure.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));

            builder.HasKey(c =>c.Id);

            builder.Property(c => c.Name)
                   .HasMaxLength(128)
                   .IsRequired();

            builder.Property(c => c.ShortName)
                   .HasMaxLength(256);

            builder.Property(c => c.Code)
                   .HasMaxLength(256);

            builder.Property(c => c.Description)
                   .HasMaxLength(1024);

            //builder.Property(c => c.IsRoot)
            //       .HasColumnName("IsRoot");

            //builder.Property(c => c.Level)
            //       .HasColumnName("Level");

            builder.Property(c => c.Delimiter)
                   .HasMaxLength(16);

            builder.Property(c => c.PathId)
                   .HasMaxLength(2048);

            builder.Property(c => c.PathName)
                   .HasMaxLength(2048);

            builder.Property(c => c.PathShortName)
                   .HasMaxLength(2048);

            //builder.Property(c => c.Published)
            //       .HasDefaultValue(true);

            //builder.Property(c => c.IsDelete)
            //       .HasColumnName("PIsDelete");

            builder.Property(c => c.PriceRanges)
                   .HasMaxLength(256);

            //builder.Property(c => c.DisplayOrder)
            //       .HasColumnName("DisplayOrder");

            //缺省日期
            builder.Property(c => c.CreatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            builder.Property(c => c.UpdatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            //builder.Property(c => c.Published)
            //       .HasDefaultValue(1);

            //builder.Property(c => c.ParentId)
            //       .HasColumnName("ParentId");

            //Unique约束
            builder.HasAlternateKey(c => c.Code);

            //一对多关系的自引用
            builder.HasMany(c => c.SubCategories)
                   .WithOne(c => c.Parent)
                   .HasForeignKey(c => c.ParentId);

        }
    }
}
