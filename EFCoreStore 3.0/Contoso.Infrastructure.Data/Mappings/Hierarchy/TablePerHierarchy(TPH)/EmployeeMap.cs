using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Contoso.Domain.Models;

namespace Contoso.Infrastructure.Data.Mappings
{
    public class EmployeeMap : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));

            builder.HasKey(e => e.Id);

            builder.Ignore(e => e.FullName);

            builder.Property(e =>e.FirstName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.LastName)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasDiscriminator<string>("EmployeeType")
                   .HasValue<Employee>("Employee_Base")
                   .HasValue<FullTimeEmployee>("Employee_FullTime")
                   .HasValue<HourlyEmployee>("Employee_Hourly"); 

            builder.Property("EmployeeType")
                   .HasMaxLength(200);
        }
    }
}
