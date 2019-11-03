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

            //枚举转化
            builder.Property(o => o.Status)
                   .HasColumnName("Status")
                   .HasConversion<string>()
                   .HasMaxLength(16);

            //缺省日期
            builder.Property(o => o.CreatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            // Configure OrderId as FK 
            builder.HasOne(o => o.DetailedOrder)
                   .WithOne()
                   .HasForeignKey<DetailedOrder>(od => od.Id);//外键，共享主键

            //DetailedOrder具有并发标记，Order必须具有并发标记,可创建一个影子状态
            builder.Property<byte[]>("Version")
                   .IsRowVersion()
                   .HasColumnName("Version");
        }
    }
}
