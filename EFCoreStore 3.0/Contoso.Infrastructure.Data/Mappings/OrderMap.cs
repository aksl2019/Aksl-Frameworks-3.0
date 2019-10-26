using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(o =>o.Id);

            //����ӻ����ʱ����ֵ
            //builder.Property(o => o.TotalExcludeCost)
            //       .HasColumnType("decimal(18,4)")
            //       .ValueGeneratedOnAddOrUpdate();

            builder.Ignore(o => o.TotalCostExcludeTax);
            builder.Ignore(o => o.TotalCostIncludeTax);

            //UniqueԼ��
           // builder.HasAlternateKey(o => o.OrderNumber);

            //builder.Property(o => o.Status)
            //     .HasMaxLength(16);

            //ö��ת��
            builder.Property(o => o.Status)
                   .HasConversion<string>()
                   .HasMaxLength(16);

            //ȱʡ����
            builder.Property(o => o.CreatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            builder.Property(o => o.CustomerName)
                   .HasMaxLength(128)
                   .IsRequired();

            //һ����������
            builder.HasMany(o => o.OrderItems)
                   .WithOne();

            //builder.HasOne(o => o.Customer)
            //       .WithMany()
            //       .HasForeignKey(o => o.CustomerId);
        }
    }
}
