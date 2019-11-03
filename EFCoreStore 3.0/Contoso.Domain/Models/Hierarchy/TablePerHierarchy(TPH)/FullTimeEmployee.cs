using System;

namespace Contoso.Domain.Models
{
    public class FullTimeEmployee : Employee
    {
        #region Constructors
        public FullTimeEmployee()
        {
        }
        #endregion

        #region Properties
        public decimal? Salary { get; set; }
        #endregion

        #region Navigation properties
        #endregion
    }
}
