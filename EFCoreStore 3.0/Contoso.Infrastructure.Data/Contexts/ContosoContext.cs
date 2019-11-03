using Microsoft.EntityFrameworkCore;

using Contoso.Domain.Models;
using Contoso.Infrastructure.Data.Mappings;

//Add-Migration init -Contex  ContosoContext
//Remove-Migration   -Contex  ContosoContext
//Update-Database init  -Contex  ContosoContext

namespace Contoso.Infrastructure.Data.Context
{
    public class ContosoContext : DbContext
    {
        protected string _connectionString = null;

        public ContosoContext(DbContextOptions<ContosoContext> options) : base(options)
        {
        }

        public string DataProviderType { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<SaleOrder> SaleOrders { get; set; }

        public DbSet<Distributor> Distributors { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public DbSet<Address> Addresses{ get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        public DbSet<HourlyEmployee> HourlyEmployees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new DetailedOrderMap());

            modelBuilder.ApplyConfiguration(new DistributorMap());

            modelBuilder.ApplyConfiguration(new SaleOrderMap());
            modelBuilder.ApplyConfiguration(new SaleOrderItemMap());

            modelBuilder.ApplyConfiguration(new InstructorMap());

            modelBuilder.ApplyConfiguration(new AddressMap());

            modelBuilder.ApplyConfiguration(new EmployeeMap());
            //modelBuilder.ApplyConfiguration(new FullTimeEmployeeMap());
            //modelBuilder.ApplyConfiguration(new HourlyEmployeeMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
