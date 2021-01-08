using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("Content")]
    public class Content
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string ContentName { set; get; }
        public string ContentDescription { set; get; }
        public string Image { set; get; }
        public long? CategoryId { set; get; }
        public string Detail { set; get; }
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
        public int? ViewCount { set; get; }
        public DateTime? TopHot { set; get; }
        public string Tags { set; get; }
    }
}
