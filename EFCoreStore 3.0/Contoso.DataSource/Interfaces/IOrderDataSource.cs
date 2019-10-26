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
      

        Task<IPagedList<OrderDto>> GetPagedOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
