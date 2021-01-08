using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        public string Id { set; get; }
        public string Name { set; get; }
    }
}
