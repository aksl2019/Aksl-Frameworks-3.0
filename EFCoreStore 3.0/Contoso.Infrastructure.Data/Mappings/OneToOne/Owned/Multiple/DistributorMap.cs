using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class DistributorMap : IEntityTypeConfiguration<Distributor>
    {
        public void Configure(EntityTypeBuilder<Distributor> builder)
        {
            builder.ToTable(nameof(Distributor));

            builder.HasKey(d => d.Id);

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
