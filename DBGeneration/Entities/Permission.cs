using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Permission")]
    public class Permission
    {
        [Key, Column(Order = 0)]
        public int RoleId { set; get; }

        [Key, Column(Order = 1)]
        public int ActionId { set; get; }

        [Key, Column(Order = 2)]
        public int FunctionId { set; get; }
    }
}
