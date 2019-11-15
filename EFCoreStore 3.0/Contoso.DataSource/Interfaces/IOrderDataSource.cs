using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Aksl.Data;

using Contoso.DataSource.Dtos;

namespace Contoso.DataSource
{
    public interface IOrderDataSource
    {

        #region TableSharing Order
        ValueTask<IEnumerable<OrderDto>> InsertOrdersAsync(IEnumerable<OrderDto> orderDtos);

        IAsyncEnumerable<OrderDto> GetPagedOrderListAsync(int pageIndex = 0, int pageSize = int.MaxValue);

      //  ValueTask<IPagedList<OrderDto>> GetPagedOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        #endregion

        #region Owned
        ValueTask<IEnumerable<SaleOrderDto>> InsertSaleOrdersAsync(IEnumerable<SaleOrderDto> saleOrderDtos);

        IAsyncEnumerable<SaleOrderDto> GetPagedSaleOrderListAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        #endregion
    }
}
