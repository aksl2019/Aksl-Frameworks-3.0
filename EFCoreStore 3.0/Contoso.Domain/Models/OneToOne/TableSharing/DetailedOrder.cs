using System;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Domain.Models
{
    public class DetailedOrder : Aksl.Data.BaseEntity
    {
        public DetailedOrder()
        {
        }

        #region Properties
        public OrderStatus? Status { get; set; }

        public string BillingAddress { get; set; }

        public string ShippingAddress { get; set; }

        public byte[] Version { get; set; }
        #endregion

        #region Navigation properties
        //共享主键
        #endregion
    }
}
