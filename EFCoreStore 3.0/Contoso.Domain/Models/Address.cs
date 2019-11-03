using System;

//Install-Package Microsoft.EntityFrameworkCore.SqlServer.NetTopologySuite -Version 3.0.0
//Install-Package Microsoft.EntityFrameworkCore.Sqlite.NetTopologySuite -Version 3.0.0
//Install-Package NetTopologySuite -Version 2.0.0

namespace Contoso.Domain.Models
{
    public class Address : Aksl.Data.BaseEntity
    {
        #region Properties
        public Address()
        {
        }
        public string Contry { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        //Geometry 类型表示欧几里得（平面）坐标系中的数据。
        public NetTopologySuite.Geometries.Point SpatialLocation { get; set; }
        #endregion

        #region Navigation properties
        #endregion
    }
}
