using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using Aksl.Data;

using Contoso.Domain.Models;
using Contoso.Domain.Repository;
using Contoso.Infrastructure.Data.Context;

namespace Contoso.Infrastructure.Data.Repository
{
    public class SqlOrderRepository : EfRepository<Order>, ISqlOrderRepository
    {
        #region Members
        private readonly IServiceProvider _serviceProvider;
        private readonly ContosoContext _contosoContext;
        private readonly IDbContextFactory<ContosoContext> _dbContextFactory;

        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        #endregion

        #region Constructors
        public SqlOrderRepository(IServiceProvider serviceProvider, IDbContextFactory<ContosoContext> dbContextFactory, ILoggerFactory loggerFactory) : base(dbContextFactory.CreateDbContext())
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _contosoContext = this._context as ContosoContext ?? throw new ArgumentNullException(nameof(ContosoContext));
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
            _loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;

            _logger = _loggerFactory.CreateLogger(nameof(SqlOrderRepository));
            _logger.LogInformation($"{nameof(SqlOrderRepository)}'s Constructor");
        }
        #endregion

        #region TableSharing Order
        public async ValueTask<IPagedList<Order>> GetPagedOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var pagedOrders = await _contosoContext.Orders.Include(oi => oi.DetailedOrder)
                                                          .AddPagedAsync(pageIndex, pageSize);

            return pagedOrders;
        }

        public async ValueTask<IEnumerable<Order>> InsertOrdersAsync(IEnumerable<Order> orders)
        {
            var newOrders = await this.InsertAsync(orders);
            return newOrders;
        }
        #endregion

        #region Owned
        public async ValueTask<IEnumerable<SaleOrder>> InsertSaleOrdersAsync(IEnumerable<SaleOrder> saleOrders)
        {
            await _contosoContext.SaleOrders.AddRangeAsync(saleOrders);
            await _contosoContext.SaveChangesAsync();
            return saleOrders;
        }

        public async ValueTask<IPagedList<SaleOrder>> GetPagedSaleOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            //var pagedSaleOrders = await _contosoContext.SaleOrders.Includes(so=> so.OrderItems, so => so.Addresses)
            //                                                      .AddPagedAsync(pageIndex, pageSize);

            var pagedSaleOrders = await _contosoContext.SaleOrders.Include(so => so.OrderItems)
                                                                  .AddPagedAsync(pageIndex, pageSize);

            return pagedSaleOrders;
        }
        #endregion

        #region Multiple Owned
        public ValueTask<IEnumerable<Distributor>> InsertDistributorsAsync(IEnumerable<Distributor> distributors)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IPagedList<Distributor>> GetPagedDistributorsAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 1  to  0..1
        public ValueTask<IEnumerable<Instructor>> InsertInstructorsAsync(IEnumerable<Instructor> instructors)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IPagedList<Instructor>> GetPagedInstructorsAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region TPH
        public ValueTask<IEnumerable<Employee>> InsertEmployeesAsync(IEnumerable<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public ValueTask<IPagedList<Employee>> GetPagedEmployeesAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }
        #endregion
 
    }
}
