using System;
using System.Collections.Generic;
using System.Linq;

namespace Contoso.Domain.Models
{
    //将两个或多个实体映射到单个行,称为 "表拆分" 或 "表共享",垂直分拆
    public class Order : Aksl.Data.BaseEntity
    {
        public Order()
        {
        }

        #region Properties
        //[Required]
        //[Column("Status", TypeName = "nvarchar(12)")]
        public OrderStatus? Status { get; set; }

        //[Required]
        //[DataType(DataType.DateTime)]
        //[Column("CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }
        #endregion

        #region Navigation properties
        public DetailedOrder DetailedOrder { get; set; }//子集,只使用表中的部分列
        #endregion
    }
}
