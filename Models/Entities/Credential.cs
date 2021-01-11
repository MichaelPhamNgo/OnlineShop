using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("Credential")]
    public class Credential
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("UserGroup")]
        public long UserGroupId { set; get; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Role")]
        public long RoleId { set; get; }

        public UserGroup UserGroup { set; get; }
        public Role Role { set; get; }
    }
}
