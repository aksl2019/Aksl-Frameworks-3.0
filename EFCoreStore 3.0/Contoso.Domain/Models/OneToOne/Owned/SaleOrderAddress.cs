using System;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Domain.Models
{
    public class SaleOrderAddress
    {
        public SaleOrderAddress()
        {
        }

        #region Properties
        public StreetAddress BillingAddress { get; set; }

        public StreetAddress ShippingAddress { get; set; }
        #endregion

        #region Navigation properties
       // public SaleOrder SaleOrder { get; set; } 
        #endregion
    }
}
