using System;
using System.Linq;
using System.Text;

namespace Contoso.DataSource.Dtos
{
    public class OrderDto
    {
        #region Properties
        public int Id { get; set; }

        public OrderStatus? Status { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string BillingAddress { get; set; }

        public string ShippingAddress { get; set; }

        public byte[] Version { get; set; }
        #endregion
    }
}
