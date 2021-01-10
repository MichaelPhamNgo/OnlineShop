using DBGeneration.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [Required]
        [DataType("decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public decimal Price { set; get; }

        [DataType("decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public decimal PromotionPrice { set; get; }

        [Required]
        [DataType("decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public decimal OriginalPrice { set; get; }

        [MaxLength(256)]
        public string Description { set; get; }

        public long ProductCategoryId { set; get; }

        [Column(TypeName = "text")]
        public string Content { set; get; }

        public bool HomeFlag { set; get; }
        public bool HotFlag { set; get; }
        public int ViewCount { set; get; }

        [MaxLength(2000)]
        public string Tags { set; get; }

        [MaxLength(256)]
        public string Unit { set; get; }
                
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }        
        public Status Status { set; get; }

        [MaxLength(256)]
        public string SeoPageTitle { set; get; }
        [MaxLength(256)]
        public string SeoAlias { set; get; }
        [MaxLength(256)]
        public string SeoKeywords { set; get; }
        [MaxLength(256)]
        public string SeoDescription { set; get; }

        public virtual ProductCategory ProductCategory { set; get; }
        public virtual ICollection<ProductImage> ProductImages { set; get; }
        public virtual ICollection<ProductQuantity> ProductQuantities { set; get; }
        public virtual ICollection<ProductTag> ProductTags { set; get; }
        public virtual ICollection<WholePrice> WholePrices { set; get; }
        public virtual ICollection<BillDetail> BillDetails { set; get; }
    }
}
