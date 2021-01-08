using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string TagName { set; get; }
        public string TagDescription { set; get; }
        public DateTime? CreatedDate { set; get; }
        public long? CreatedBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public long? ModifiedBy { set; get; }
        public Status Status { set; get; }
    }
}
