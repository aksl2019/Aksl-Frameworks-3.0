using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class FullTimeEmployeeMap : IEntityTypeConfiguration<FullTimeEmployee>
    {
        public void Configure(EntityTypeBuilder<FullTimeEmployee> builder)
        {
            builder.ToTable(nameof(FullTimeEmployee));

            builder.Property(e =>e.Salary)
                   .HasColumnType("money");

        }
    }
}
