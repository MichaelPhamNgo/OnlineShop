using DBGeneration.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string Text { set; get; }
        public string Link { set; get; }
        public string Target { set; get; }
        public int? DisplayOrder { set; get; }
        public Status Status { set; get; }
        public int? TypeId { set; get; }
    }
}
