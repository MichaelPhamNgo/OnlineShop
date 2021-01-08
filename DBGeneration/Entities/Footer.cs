using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        [StringLength(50)]
        [DataType("varchar")]
        public string Id { set; get; }
        public string Detail { set; get; }
        public Status Status { set; get; }
    }
}
