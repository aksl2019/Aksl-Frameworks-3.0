using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class SaleOrderMap : IEntityTypeConfiguration<SaleOrder>
    {
        public void Configure(EntityTypeBuilder<SaleOrder> builder)
        {
            builder.ToTable(nameof(SaleOrder));

            builder.HasKey(o => o.Id);

            //����ӻ����ʱ����ֵ
            //builder.Property(o => o.TotalExcludeCost)
            //       .HasColumnType("decimal(18,4)")
            //       .ValueGeneratedOnAddOrUpdate();

            builder.Ignore(o => o.TotalCostExcludeTax);
            builder.Ignore(o => o.TotalCostTax);
            builder.Ignore(o => o.TotalCostIncludeTax);

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

            //https://docs.microsoft.com/zh-cn/ef/core/modeling/relationships
            //������������
            builder.HasMany(o => o.OrderItems)
                   .WithOne();

            //1.ָ��ShippingAddress������Orderʵ�����͵�ӵ��ʵ�壬ͬһ����
            //builder.OwnsOne(so => so.ShippingAddress);

            //2.ָ��ShippingAddress������Orderʵ�����͵�ӵ��ʵ�壬ͬһ����,ָ���е�����
            //builder.OwnsOne(so => so.ShippingAddress,
            //              onb =>
            //              {
            //                  onb.Property(sa => sa.Street).HasColumnName("ShipsToStreet");
            //                  onb.Property(sa => sa.City).HasColumnName("ShipsToCity");
            //              });

            //3.�洢�ڵ����ı���
            //builder.OwnsOne(so => so.ShippingAddress,
            //                onb =>
            //                {
            //                    onb.ToTable("ShippingAddress");
            //                });

            //builder.OwnsOne(so => so.OrderDetail,
            //               onb =>
            //               {
            //                   //onb.WithOwner(sod=>sod.SaleOrder);
            //                   onb.OwnsOne(sod => sod.BillingAddress);
            //                   onb.OwnsOne(sod => sod.ShippingAddress);
            //               });

            builder.OwnsOne(so => so.OrderDetail,
                          onb =>
                          {
                              onb.ToTable("SaleOrderDetail");
                              // onb.OwnsOne(sod => sod.BillingAddress);
                              onb.OwnsOne(sod => sod.BillingAddress,
                              onbb =>
                              {
                                  onbb.ToTable("SaleOrderBillingAddress");
                              });
                           //   onb.OwnsOne(sod => sod.ShippingAddress);
                              onb.OwnsOne(sod => sod.ShippingAddress,
                                 onbb =>
                                 {
                                     onbb.ToTable("SaleOrderShippingAddress");
                                 });
                          });
        }
    }
}
