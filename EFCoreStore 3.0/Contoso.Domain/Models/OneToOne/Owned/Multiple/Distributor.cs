using System;
using System.Collections.Generic;

//https://docs.microsoft.com/zh-cn/ef/core/modeling/owned-entities

namespace Contoso.Domain.Models
{
    //分销商或经销商
    public class Distributor : Aksl.Data.BaseEntity
    {
        #region Properties
        public string Name { get; set; }
        #endregion

        #region Navigation properties
        public ICollection<StreetAddress> ShippingCenters { get; set; }
        #endregion
    }
}
