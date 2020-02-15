using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

//https://docs.microsoft.com/zh-cn/ef/core/modeling/owned-entities

namespace Contoso.Infrastructure.Data.Mappings
{
    public class DistributorMap : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.ToTable(nameof(Distributor));

            builder.HasKey(d => d.Id);

            builder.Property(e => e.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            // builder.OwnsMany<StreetAddress>(d => d.ShippingCenters);

            builder.OwnsMany<StreetAddress>(d => d.ShippingCenters, onb =>
            {
                onb.ToTable("ShippingCenters");
                onb.WithOwner().HasForeignKey("OwnerId");//Íâ¼ü
                onb.Property<int>("Id");
                onb.HasKey("Id");//Ö÷¼ü
            });
        }
    }
}
