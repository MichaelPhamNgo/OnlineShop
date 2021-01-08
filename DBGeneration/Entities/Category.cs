using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string CategoryName { set; get; }
        public string CategoryDescription { set; get; }
        public long? ParentId { set; get; }
        public int? DisplayOrder { set; get; }
        public string SeoTitle { set; get; }
        public string MetaTitle { set; get; }
        public string MetaKeywords { set; get; }
        public string MetaDescription { set; get; }
        public DateTime? CreatedDate { set; get; }
        public long? CreatedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public long? ModifiedBy { set; get; }
        public Status Status { set; get; }
        public bool? ShowOnHome { set; get; }
    }
}
