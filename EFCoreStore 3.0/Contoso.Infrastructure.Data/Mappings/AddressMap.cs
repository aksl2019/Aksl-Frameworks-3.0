using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;
namespace Contoso.Domain.Models
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable(nameof(Address));

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Contry)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.State)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.City)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.AddressLine1)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(a => a.AddressLine2)
                   .HasMaxLength(100);

            builder.Property(a => a.PostalCode)
                   .HasMaxLength(20)
                   .IsRequired();

            //builder.Property(a => a.SpatialLocation)
            //       .HasColumnType("geography");

        }
    }
}
