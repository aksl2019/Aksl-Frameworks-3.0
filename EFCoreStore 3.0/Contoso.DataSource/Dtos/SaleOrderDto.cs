using System;
using System.Linq;
using System.Text;

namespace Contoso.DataSource.Dtos
{
    public class SaleOrderDto
    {
        //public PurchaseOrderDto() { }

        #region Properties
        public int Id { get; set; }

        public int OrderNumber { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public string CustomerId { get; set; }

        /// <summary>
        /// 不含税总金额
        /// </summary>
        public decimal TotalCostExcludeTax => OrderLineItems.Sum(oi => oi.TotalCostExcludeTax);

        /// <summary>
        /// 税的总金额
        /// </summary>
        public decimal TotalCostTax => OrderLineItems.Sum(oi => oi.TotalCostTax);

        //[DataType(DataType.Currency)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Column("TotalCost", TypeName = "money", Order = 6)]
        /// <summary>
        /// 含税总金额
        /// </summary>
        public decimal TotalCostIncludeTax => OrderLineItems.Sum(oi => oi.TotalCostIncludeTax);
        #endregion

        #region Owned Properties
        public string BillingAddressCity { get; set; }

        public string BillingAddressStreet { get; set; }

        public string ShippingAddressCity { get; set; }

        public string ShippingAddressStreet { get; set; }
        #endregion

        #region Navigation properties
        public SaleOrderLineItemDto[] OrderLineItems { get; set; }
        #endregion

        public override string ToString()
        {
            StringBuilder strbuf = new StringBuilder($"OrderId: {Id}\n");
            strbuf.Append($"\tOrder Number: {OrderNumber}\n");
            strbuf.Append($"\tOrder status: {Status}\n");
            strbuf.Append($"\tCreatedDate: {CreatedOnUtc.ToLocalTime()}\n");
            strbuf.Append($"\tCustomer: {CustomerId}\n");
            strbuf.Append($"\tBillingAddress: {BillingAddressStreet},{BillingAddressCity}\n");
            strbuf.Append($"\tShippingAddress: {ShippingAddressStreet},{ShippingAddressCity}\n");
            strbuf.Append("\tOrderDetails\n");

            foreach (SaleOrderLineItemDto lineItem in OrderLineItems)
            {
                strbuf.Append("\t\t" + lineItem.ToString());
            }

            strbuf.Append($"\tTotal exclude tax cost of this order: ${TotalCostExcludeTax}\n");
            strbuf.Append($"\t              tax cost of this order: ${TotalCostTax}\n");
            strbuf.Append($"\tTotal include tax cost of this order: ${TotalCostIncludeTax}\n");

            return strbuf.ToString();
        }
    }
}
