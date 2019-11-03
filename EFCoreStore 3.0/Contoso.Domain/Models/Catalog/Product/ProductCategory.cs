
namespace Contoso.Domain.Models
{
    public class ProductCategory : Aksl.Data.BaseEntity
    {
        public ProductCategory()
        {
        }

        #region Properties
     //   public int Id { get; set; }

        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }
        #endregion

        #region Navigation properties
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
        #endregion
    }
}
