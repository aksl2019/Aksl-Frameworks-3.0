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
    }
}
