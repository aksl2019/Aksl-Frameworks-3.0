using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class HourlyEmployeeMap : IEntityTypeConfiguration<HourlyEmployee>
    {
        public void Configure(EntityTypeBuilder<HourlyEmployee> builder)
        {
            builder.ToTable(nameof(HourlyEmployee));

            builder.Property(e =>e.Wage)
                   .HasColumnType("money");

        }
    }
}
