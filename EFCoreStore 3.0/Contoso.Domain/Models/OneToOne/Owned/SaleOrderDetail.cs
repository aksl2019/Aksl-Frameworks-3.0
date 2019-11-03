using System;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Domain.Models
{
    public class SaleOrderDetail/* : Aksl.Data.BaseEntity*/
    {
        public SaleOrderDetail()
        {
        }

        #region Properties
        public OrderStatus? Status { get; set; }

        public StreetAddress BillingAddress { get; set; }

        public StreetAddress ShippingAddress { get; set; }
        #endregion

        #region Navigation properties
       // public SaleOrder SaleOrder { get; set; } 
        #endregion
    }
}
