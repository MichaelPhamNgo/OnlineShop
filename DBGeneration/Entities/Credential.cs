using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Credential")]
    public class Credential
    {
        [Key, Column(Order = 0)]
        public string UserGroupId { set; get; }
        [Key, Column(Order = 1)]
        public string RoleId { set; get; }
    }
}
