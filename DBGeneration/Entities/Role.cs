using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public string Id { set; get; }
        public string Name { set; get; }
    }
}
