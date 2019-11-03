using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contoso.Domain.Models
{
    //自引用的一对多关系
    //[Table("Category")]
    public class Category : Aksl.Data.BaseEntity
    {
        #region Constructors
        public Category()
        {
            SubCategories = new HashSet<Category>();
            ProductCategories = new HashSet<ProductCategory>();
        }
        #endregion

        #region Properties
        //[Key]
        //[Column("Id")]
        //public int Id { get; set; }

        //[Required]
        //[StringLength(128)]
        //[Column("Name")]
        public string Name { get; set; }

        //[StringLength(256)]
        //[Column("ShortName")]
        public string ShortName { get; set; }

        //[Required]
        //[StringLength(256)]
        //[Column("Code")]
        public string Code { get; set; }

        //[StringLength(1024)]
        //[Column("Description")]
        public string Description { get; set; }

        //[Column("IsRoot")]
        public bool IsRoot { get; set; }

        //[Column("Level")]
        public int Level { get; set; }

        //[StringLength(16)]
        //[Column("Delimiter")]
        public string Delimiter { get; set; }

        //[StringLength(2048)]
        //[Column("PathId")]
        public string PathId { get; set; }

        //[StringLength(2048)]
        //[Column("PathName")]
        public string PathName { get; set; }

        //[StringLength(2048)]
        //[Column("PathShortName")]
        public string PathShortName { get; set; }

        //[Column("Published")]
        public bool Published { get; set; }

        //[Column("IsDelete")]
        public bool IsDelete { get; set; }

        /// <summary>
        /// Gets or sets the available price ranges,"-25;25-50;50-;","0-500;500-700;700-3000;"
        /// </summary>
        //[StringLength(512)]
        //[Column("PriceRanges")]
        public string PriceRanges { get; set; }

        //[Column("DisplayOrder")]
        public int DisplayOrder { get; set; }

        //[DataType(DataType.DateTime)]
        //[Column("CreatedOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        //[DataType(DataType.DateTime)]
        //[Column("UpdatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }
        #endregion

        #region Navigation properties
       // [Column("ParentId")]
        public int? ParentId { get; set; }

        //[ForeignKey("ParentId")]
        public Category Parent { get; set; }

        public ICollection<Category> SubCategories { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
        #endregion
    }
}
