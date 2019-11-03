using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class InstructorMap : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable(nameof(Instructor));

            builder.HasKey(i => i.Id);

            builder.Ignore(i => i.FullName);

            builder.Property(i => i.FirstMidName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(i => i.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            //È±Ê¡ÈÕÆÚ
            builder.Property(i => i.HireDateUtc)
                   .HasColumnType("datetime2")
                   .HasDefaultValueSql("getdate()");

            //1  to  0.1
            builder.HasOne(i => i.OfficeAddress)
                   .WithOne()
                   .HasForeignKey<Instructor>(i => i.AddressId);
        }
    }
}
