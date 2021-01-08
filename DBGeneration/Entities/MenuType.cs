using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("MenuType")]
    public class MenuType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [StringLength(250)]
        [DataType("nvarchar")]
        public string MenuTypeName { set; get; }
    }
}
