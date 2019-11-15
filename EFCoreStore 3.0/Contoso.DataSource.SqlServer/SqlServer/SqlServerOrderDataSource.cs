using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

using AutoMapper;

using Aksl.Data;

using Contoso.Domain.Repository;
using Contoso.DataSource.Dtos;
using Contoso.Domain.Models;

namespace Contoso.DataSource.SqlServer
{
    public class SqlServerOrderDataSource : ISqlServerOrderDataSource
    {
        #region Members
        private readonly IMapper _mapper;
        private readonly ISqlOrderRepository _sqlOrderRepository;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        #endregion

        #region Constructors
        public SqlServerOrderDataSource(IMapper mapper, ISqlOrderRepository sqlOrderRepository, ILoggerFactory loggerFactory)
        {
            _sqlOrderRepository = sqlOrderRepository ?? throw new ArgumentNullException(nameof(sqlOrderRepository));
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
            _loggerFactory = loggerFactory ?? NullLoggerFactory.Instance;

            _logger = _loggerFactory.CreateLogger(nameof(SqlServerOrderDataSource));
            _logger.LogInformation($"{nameof(SqlServerOrderDataSource)} 's Constructor");
            //_logger.LogInformation($"{this.GetType().FullName}'s Constructor");
        }
        #endregion

        #region TableSharing Order
        public async ValueTask<IEnumerable<OrderDto>> InsertOrdersAsync(IEnumerable<OrderDto> orderDtos)
        {
            try
            {
                var orderModels = _mapper.Map<IEnumerable<Order>>(orderDtos);
                var newOrderModels = await _sqlOrderRepository.InsertOrdersAsync(orderModels);
                var newOrderDtos = _mapper.Map<IEnumerable<OrderDto>>(newOrderModels);
                return newOrderDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetPagedOrdersAsync)} Error: {ex.Message}");

                throw ex;
            }
        }

        public async IAsyncEnumerable<OrderDto> GetPagedOrderListAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var pagedOrders = await _sqlOrderRepository.GetPagedOrdersAsync(pageIndex, pageSize);
            var pagedOrderDtos = await _mapper.Map<IEnumerable<OrderDto>>(pagedOrders.AsEnumerable()).AddPagedAsync(pageIndex, pageSize);

            foreach (var orderDto in pagedOrderDtos)
            {
                yield return orderDto;
            }
        }

        public async ValueTask<IPagedList<OrderDto>> GetPagedOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            try
            {
                var pagedOrders = await _sqlOrderRepository.GetPagedOrdersAsync(pageIndex, pageSize);
                var pagedOrderDtos = await _mapper.Map<IEnumerable<OrderDto>>(pagedOrders.AsEnumerable()).AddPagedAsync(pageIndex, pageSize);
                return pagedOrderDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(GetPagedOrdersAsync)} Error: {ex.Message}");

                throw ex;
            }
        }
        #endregion

        #region Owned
        public async ValueTask<IEnumerable<SaleOrderDto>> InsertSaleOrdersAsync(IEnumerable<SaleOrderDto> saleOrderDtos)
        {
            try
            {
                var saleOrderModels = _mapper.Map<IEnumerable<SaleOrder>>(saleOrderDtos);
                var newSaleOrderModels = await _sqlOrderRepository.InsertSaleOrdersAsync(saleOrderModels);
                var newSaleOrderDtos = _mapper.Map<IEnumerable<SaleOrderDto>>(newSaleOrderModels);
                return newSaleOrderDtos;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(InsertSaleOrdersAsync)} Error: {ex.Message}");

                throw ex;
            }
        }

        public async IAsyncEnumerable<SaleOrderDto> GetPagedSaleOrderListAsync(int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var pagedSaleOrders = await _sqlOrderRepository.GetPagedSaleOrdersAsync(pageIndex, pageSize);
            var pagedSaleOrderDtos = await _mapper.Map<IEnumerable<SaleOrderDto>>(pagedSaleOrders.AsEnumerable()).AddPagedAsync(pageIndex, pageSize);

            foreach (var orderDto in pagedSaleOrderDtos)
            {
                yield return orderDto;
            }
        }
        #endregion
    }
}
