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

            builder.OwnsOne(so => so.Addresses,
                          onb1 =>
                          {
                              onb1.ToTable("SaleOrderAddresses");
                              onb1.WithOwner().HasForeignKey("OwnerId");//���;
                              onb1.Property<int>("Id");
                              onb1.HasKey("Id");//����
                              // onb.OwnsOne(sod => sod.BillingAddress);
                              onb1.OwnsOne(sod => sod.BillingAddress,
                              onb2 =>
                              {
                                  onb2.ToTable("SaleOrderBillingAddress");
                                  onb2.WithOwner().HasForeignKey("OwnerId");//���;
                                  onb2.Property<int>("Id");
                                  onb2.HasKey("Id");//����
                              });
                              //   onb.OwnsOne(sod => sod.ShippingAddress);
                              onb1.OwnsOne(sod => sod.ShippingAddress,
                              onb3 =>
                              {
                                  onb3.ToTable("SaleOrderShippingAddress");
                                  onb3.WithOwner().HasForeignKey("OwnerId");//���;
                                  onb3.Property<int>("Id");
                                  onb3.HasKey("Id");//����
                              });
                          });
        }
    }
}
