using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using Aksl.Concurrency;

using Contoso.Domain.Models;
using Contoso.DataSource.Dtos;
using Contoso.DataSource;

namespace Contoso.ConsoleApp
{
    public partial class WebApiSender
    {
        #region SaleOrders Page
        public async ValueTask GetPagedSaleOrdersAsync()
        {
            int pageIndex = 0;
            int pageSize = int.MaxValue;

            var logger = _loggerFactory.CreateLogger($"{ nameof(GetPagedSaleOrdersAsync)}");

            try
            {
                var executionTimeWatcher = Stopwatch.StartNew();

                var contosoDataSourceFactory = this.ServiceProvider.GetRequiredService<IDataSourceFactory<IContosoDataSource>>();
                var orderDataSource = contosoDataSourceFactory.Current.OrderDataSource;

                logger.LogInformation($"----begin read sale orders, pageIndex:{ pageIndex}, pageSize:{  pageSize},now:{DateTime.Now.TimeOfDay}----");

                var pagedOrderDtos = orderDataSource.GetPagedSaleOrderListAsync(pageIndex, pageSize);

                int totalCount = 0;
                await foreach (var order in pagedOrderDtos)
                {
                    totalCount++;
                    //Console.WriteLine($"OrderId: {order.Id},OrderStatus: {order.Status}");
                    Console.WriteLine($"{order.ToString()}");
                }

                logger
                   .LogInformation($"----read { totalCount} sale orders,cost time:\"{executionTimeWatcher.Elapsed}\",count/time(sec):{Math.Ceiling(totalCount / executionTimeWatcher.Elapsed.TotalSeconds)},now:\"{DateTime.Now.TimeOfDay}\"----");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n");
            }
        }
        #endregion
    }
}
