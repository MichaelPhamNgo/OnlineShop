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
        [StringLength(50)]
        [DataType("varchar")]
        public string Id { set; get; }
        public string SystemConfigName { set; get; }
        public string Type { set; get; }
        public string Value { set; get; }
        public Status Status { set; get; }
    }
}
