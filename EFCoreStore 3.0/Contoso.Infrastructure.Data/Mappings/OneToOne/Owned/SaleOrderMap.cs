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

            //在添加或更新时生成值
            //builder.Property(o => o.TotalExcludeCost)
            //       .HasColumnType("decimal(18,4)")
            //       .ValueGeneratedOnAddOrUpdate();

            builder.Ignore(o => o.TotalCostExcludeTax);
            builder.Ignore(o => o.TotalCostTax);
            builder.Ignore(o => o.TotalCostIncludeTax);

            //枚举转化
            builder.Property(o => o.Status)
                   .HasConversion<string>()
                   .HasMaxLength(16);

            //缺省日期
            builder.Property(o => o.CreatedOnUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            builder.Property(o => o.CustomerName)
                   .HasMaxLength(128)
                   .IsRequired();

            //https://docs.microsoft.com/zh-cn/ef/core/modeling/relationships
            //单个导航属性
            builder.HasMany(o => o.OrderItems)
                   .WithOne();

            //1.指定ShippingAddress属性是Order实体类型的拥有实体，同一个表
            //builder.OwnsOne(so => so.ShippingAddress);

            //2.指定ShippingAddress属性是Order实体类型的拥有实体，同一个表,指定列得名称
            //builder.OwnsOne(so => so.ShippingAddress,
            //              onb =>
            //              {
            //                  onb.Property(sa => sa.Street).HasColumnName("ShipsToStreet");
            //                  onb.Property(sa => sa.City).HasColumnName("ShipsToCity");
            //              });

            //3.存储在单独的表中
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
                              onb1.WithOwner().HasForeignKey("OwnerId");//外键;
                              onb1.Property<int>("Id");
                              onb1.HasKey("Id");//主键
                              // onb.OwnsOne(sod => sod.BillingAddress);
                              onb1.OwnsOne(sod => sod.BillingAddress,
                              onb2 =>
                              {
                                  onb2.ToTable("SaleOrderBillingAddress");
                                  onb2.WithOwner().HasForeignKey("OwnerId");//外键;
                                  onb2.Property<int>("Id");
                                  onb2.HasKey("Id");//主键
                              });
                              //   onb.OwnsOne(sod => sod.ShippingAddress);
                              onb1.OwnsOne(sod => sod.ShippingAddress,
                              onb3 =>
                              {
                                  onb3.ToTable("SaleOrderShippingAddress");
                                  onb3.WithOwner().HasForeignKey("OwnerId");//外键;
                                  onb3.Property<int>("Id");
                                  onb3.HasKey("Id");//主键
                              });
                          });
        }
    }
}
