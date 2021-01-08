using DBGeneration.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Function")]
    public class Function
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }        
        public string FunctionName { set; get; }
        public long? ParentId { set; get; }
        public int? DisplayOrder { set; get; }
        public Status Status { set; get; }
        public string URL { set; get; }
        public string IconCss { set; get; }
    }
}
