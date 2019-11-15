using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Aksl.Data;
using Aksl.Concurrency;

using Contoso.DataSource.Dtos;
using Contoso.DataSource;

namespace Contoso.ConsoleApp
{
    public partial class WebApiSender
    {
        #region TableSharing Order

        public async ValueTask InsertOrdersAsync()
        {
            var logger = _loggerFactory.CreateLogger($"{ nameof(InsertOrdersAsync)}");

            try
            {
                var executionTimeWatcher = Stopwatch.StartNew();

                var contosoDataSourceFactory = this.ServiceProvider.GetRequiredService<IDataSourceFactory<IContosoDataSource>>();
                var orderDataSource = contosoDataSourceFactory.Current.OrderDataSource;

                var orderDtos = new OrderDto[]
                {
                    new OrderDto
                    {
                        Status = OrderStatus.Pending,
                        ShippingAddress = "221 B Baker St, London",
                        BillingAddress = "11 Wall Street, New York"
                    }, 
                    new OrderDto
                    {
                        Status = OrderStatus.Shipped,
                        ShippingAddress = "222 B Baker St, London",
                        BillingAddress = "12 Wall Street, New York"
                    }
               };

                var newOrderDtos = await orderDataSource.InsertOrdersAsync(orderDtos);

                logger
                    .LogInformation($"----Insert {newOrderDtos.Count()} orders,cost time:\"{executionTimeWatcher.Elapsed}\",count/time(sec):{Math.Ceiling(newOrderDtos.Count() / executionTimeWatcher.Elapsed.TotalSeconds)},now:\"{DateTime.Now.TimeOfDay}\"----");

                foreach (var order in newOrderDtos)
                {
                    Console.WriteLine($"OrderId: {order.Id},OrderStatus: {order.Status}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n");
            }
        }

        public async ValueTask GetPagedOrdersAsync()
        {
            int pageIndex = 0;
            int pageSize = int.MaxValue;

            var logger = _loggerFactory.CreateLogger($"{ nameof(GetPagedOrdersAsync)}");

            try
            {
                var executionTimeWatcher = Stopwatch.StartNew();

                var contosoDataSourceFactory = this.ServiceProvider.GetRequiredService<IDataSourceFactory<IContosoDataSource>>();
                var orderDataSource = contosoDataSourceFactory.Current.OrderDataSource;

                logger.LogInformation($"----begin read orders, pageIndex:{ pageIndex}, pageSize:{  pageSize},now:{DateTime.Now.TimeOfDay}----");

                var pagedOrderDtos =  orderDataSource.GetPagedOrderListAsync(pageIndex, pageSize);

                int totalCount= 0;
                await foreach (var order in pagedOrderDtos)
                {
                    totalCount++;
                    Console.WriteLine($"OrderId: {order.Id},,OrderStatus: {order.Status}");
                }

                logger
                   .LogInformation($"----read { totalCount} orders,cost time:\"{executionTimeWatcher.Elapsed}\",count/time(sec):{Math.Ceiling(totalCount / executionTimeWatcher.Elapsed.TotalSeconds)},now:\"{DateTime.Now.TimeOfDay}\"----");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n");
            }
        }
        #endregion
    }
}
