using System;

namespace Contoso.Domain.Models
{
    public class Employee : Aksl.Data.BaseEntity
    {
        #region Constructors
        public Employee()
        {
        }
        #endregion

        #region Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => LastName + ", " + FirstName;
        #endregion

        #region Navigation properties
        #endregion
    }
}
