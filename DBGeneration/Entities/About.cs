using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("About")]
    public class About
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string AboutName { set; get; }
        public string AboutDescription { set; get; }
        public string Image { set; get; }
        public string Detail { set; get; }
        public string MetaTitle { set; get; }
        public string SeoTitle { set; get; }
        public string MetaKeywords { set; get; }
        public string MetaDescription { set; get; }
        public DateTime? CreatedDate { set; get; }
        public long? CreatedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public long? ModifiedBy { set; get; }
        public Status Status { set; get; }
    }
}
