using System;
using System.Collections.Generic;

namespace Contoso.Domain.Models
{
    public class Distributor : Aksl.Data.BaseEntity
    {
        #region Properties
       
        #endregion

        #region Navigation properties
        public ICollection<StreetAddress> ShippingCenters { get; set; }
        #endregion
    }
}
