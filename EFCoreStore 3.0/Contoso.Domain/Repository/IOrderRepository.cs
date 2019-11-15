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
        #region TableSharing Order
        ValueTask<IEnumerable<Order>> InsertOrdersAsync(IEnumerable<Order> orders);

        ValueTask<IPagedList<Order>> GetPagedOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        #endregion

        #region Owned
        ValueTask<IEnumerable<SaleOrder>> InsertSaleOrdersAsync(IEnumerable<SaleOrder> saleOrders);

        ValueTask<IPagedList<SaleOrder>> GetPagedSaleOrdersAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        #endregion

        #region Multiple Owned
        ValueTask<IEnumerable<Distributor>> InsertDistributorsAsync(IEnumerable<Distributor> distributors);

        ValueTask<IPagedList<Distributor>> GetPagedDistributorsAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        #endregion

        #region 1  to  0..1
        ValueTask<IEnumerable<Instructor>> InsertInstructorsAsync(IEnumerable<Instructor> instructors);

        ValueTask<IPagedList<Instructor>> GetPagedInstructorsAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        #endregion

        #region TPH
        ValueTask<IEnumerable<Employee>> InsertEmployeesAsync(IEnumerable<Employee> employees);

        ValueTask<IPagedList<Employee>> GetPagedEmployeesAsync(int pageIndex = 0, int pageSize = int.MaxValue);
        #endregion

    }
}
