using System;

namespace Contoso.Domain.Models
{
    public class StreetAddress /*: Aksl.Data.BaseEntity*/
    {
        #region Properties
        public string Street { get; set; }
        #endregion

        #region Navigation properties
        public string City { get; set; }
        #endregion
    }
}
