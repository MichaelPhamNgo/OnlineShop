using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string Image { set; get; }
        public string Description { set; get; }
        public string Sale { set; get; }
        public int? UpTo { set; get; }
        public int? DisplayOrder { set; get; }
        public string Link { set; get; }
        public DateTime? CreatedDate { set; get; }
        public long? CreatedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public long? ModifiedBy { set; get; }
        public Status Status { set; get; }
    }
}
