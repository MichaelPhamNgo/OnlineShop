using DBGeneration.Enums;
using System;
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

        public string ProductCode { set; get; }
        public string ProductName { set; get; }
        public string Image { set; get; }
        public string MoreImages { set; get; }

        [DataType("decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public decimal Price { set; get; }

        [DataType("decimal(18, 2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        public decimal PromotionPrice { set; get; }

        public bool? IncludeVAT { set; get; }
        public int? Quantity { set; get; }
        public long? CategoryId { set; get; }
        public string Detail { set; get; }
        public int? Warranty { set; get; }
        public string MetaTitle { set; get; }
        public string SeoTitle { set; get; }
        public string MetaKeywords { set; get; }
        public string MetaDescription { set; get; }
        public DateTime? CreatedDate { set; get; }
        public long? CreatedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public long? ModifiedBy { set; get; }
        public Status Status { set; get; }
        public DateTime? TopHot { set; get; }
        public int? ViewCount { set; get; }
    }
}
