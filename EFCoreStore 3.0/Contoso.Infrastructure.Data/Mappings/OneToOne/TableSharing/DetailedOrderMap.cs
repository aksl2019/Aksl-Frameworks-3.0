using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class DetailedOrderMap : IEntityTypeConfiguration<DetailedOrder>
    {
        public void Configure(EntityTypeBuilder<DetailedOrder> builder)
        {
            builder.ToTable(nameof(Order));

            builder.Ignore(od =>od.Id);//忽略掉主键，使用共享主键

            // builder.HasKey(op => op.OrderId);

            builder.Property(od => od.Version)
                   .IsRowVersion()
                   .HasColumnName("Version"); ;

            //枚举转化
            builder.Property(od => od.Status)
                   .HasColumnName("Status")
                   .HasConversion<string>()
                   .HasMaxLength(16);

         
        }
    }
}
