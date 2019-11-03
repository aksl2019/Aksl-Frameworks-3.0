using System;


namespace Contoso.Domain.Models
{
    public class HourlyEmployee : Employee
    {
        #region Constructors
        public HourlyEmployee()
        {
        }
        #endregion

        #region Properties
        public decimal? Wage { get; set; }
        #endregion

        #region Navigation properties
        #endregion
    }
}
