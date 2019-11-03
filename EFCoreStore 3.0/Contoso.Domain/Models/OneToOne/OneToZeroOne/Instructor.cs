using System;

namespace Contoso.Domain.Models
{
    //讲师
    public class Instructor : Aksl.Data.BaseEntity
    {
        public Instructor()
        {
        }

        #region Properties
        public string LastName { get; set; }

        public string FirstMidName { get; set; }

        public DateTime HireDateUtc { get; set; }

        public string FullName => LastName + ", " + FirstMidName;
        #endregion

        #region Navigation properties
        public int? AddressId { get; set; }

        public Address OfficeAddress { get; set; }
        #endregion
    }
}
