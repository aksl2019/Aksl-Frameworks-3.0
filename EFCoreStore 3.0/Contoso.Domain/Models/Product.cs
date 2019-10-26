using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insurance.Management.Domain.Models
{
    public class Product : Aksl.Data.BaseEntity
    {
        #region Constructors
        public Product()
        {
            SubProducts = new HashSet<Product>();
        }
        #endregion

        #region Properties
        //public int Id { get; set; }

        //[Required]
        //[StringLength(2048)]
        //[Column("Name")]
        public string Name { get; set; }

        //[StringLength(1024)]
        //[Column("Alias")]
        public string Alias { get; set; }

        //[StringLength(512)]
        //[Column("Code")]
        public string Code { get; set; }

        //[StringLength(2048)]
        //[Column("Description")]
        public string Description { get; set; }

        //[StringLength(2048)]
        //[Column("Sku")]
        public string Sku { get; set; }

        //[DataType(DataType.Currency)]
        //[Column("Price", TypeName = "money")]
        public decimal Price { get; set; }

        //[DataType(DataType.Currency)]
        //[Column("OldPrice", TypeName = "money")]
        public decimal OldPrice { get; set; }

        //[DataType(DataType.Currency)]
        //[Column("ProductCost", TypeName = "money")]
        public decimal ProductCost { get; set; }

        //[DataType(DataType.Currency)]
       // [Column("SpecialPrice", TypeName = "money")]
        //public decimal? SpecialPrice { get; set; }

        //Gets or sets the start date and time of the special price
        //[DataType(DataType.DateTime)]
        //public DateTime? SpecialPriceStartDateTimeUtc { get; set; }

        // Gets or sets the end date and time of the special price
        //[DataType(DataType.DateTime)]
        //public DateTime? SpecialPriceEndDateTimeUtc { get; set; }

        //[Required]
        //[Column("Status", TypeName = "nvarchar(12)")]
        //public string Status { get; set; }

        //是否免费
        //[Column("IsTaxExempt")]
        public bool IsTaxExempt { get; set; }

        //[Column("TaxCategoryId")]
        public int TaxCategoryId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this product is marked as new
        /// </summary>
       // [Column("MarkAsNew")]
        public bool MarkAsNew { get; set; }

        /// <summary>
        /// Gets or sets the start date and time of the new product (set product as "New" from date). Leave empty to ignore this property
        /// </summary>
       // [DataType(DataType.DateTime)]
      //  [Column("MarkAsNewStartDateTimeUtc")]
        public DateTime? MarkAsNewStartDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the end date and time of the new product (set product as "New" to date). Leave empty to ignore this property
        /// </summary>
      //  [DataType(DataType.DateTime)]
      //  [Column("MarkAsNewEndDateTimeUtc")]
        public DateTime? MarkAsNewEndDateTimeUtc { get; set; }

        //Gets or sets a value indicating whether the entity is subject to ACL
      //  [Column("SubjectToAcl")]
        public bool SubjectToAcl { get; set; }

      //  [Column("Published")]
        public bool Published { get; set; }

      //  [Column("IsDelete")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// Gets or sets the available start date and time
        /// </summary>
      //  [DataType(DataType.DateTime)]
     //   [Column("AvailableStartDateTimeUtc")]
        public DateTime? AvailableStartDateTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the available end date and time
        /// </summary>
       // [DataType(DataType.DateTime)]
      //  [Column("AvailableEndDateTimeUtc")]
        public DateTime? AvailableEndDateTimeUtc { get; set; }

      //  [Column("DisplayOrder")]
        public int DisplayOrder { get; set; }

      //  [DataType(DataType.DateTime)]
      //  [Column("CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

     //   [DataType(DataType.DateTime)]
     //   [Column("UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }
        #endregion

        #region Navigation properties
       // [Column("ParentId")]
        public int? ParentId { get; set; }

        //[ForeignKey("ParentId")]
        public Product Parent { get; set; }

        public ICollection<Product> SubProducts { get; set; }

        #endregion
    }
}
