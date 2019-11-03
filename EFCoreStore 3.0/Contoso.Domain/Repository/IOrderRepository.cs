using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Aksl.Data;

using Contoso.Domain.Models;

namespace Contoso.Domain.Repository
{
    public interface IOrderRepository 
    {
       ValueTask<IEnumerable<Order>> InsertOrdersAsync(IEnumerable<Order> orders);

        ValueTask<IPagedList<Order>> GetPagedOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
