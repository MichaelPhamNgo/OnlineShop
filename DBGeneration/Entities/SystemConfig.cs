using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("SystemConfig")]
    public class SystemConfig
    {
        [Key]
        [StringLength(255)]
        [Column(TypeName = "varchar")]
        public string Id { set; get; }

        [StringLength(128)]
        [Column(TypeName = "varchar")]
        public string Name { set; get; }
                
        [Column(TypeName = "text")]
        public string Value1 { set; get; }                
        public int Value2 { set; get; }
        public bool Value3 { set; get; }
        public DateTime Value4 { set; get; }
        [DataType("decimal(18, 2)")]
        public decimal Value5 { set; get; }
        public Status Status { set; get; }
    }
}
