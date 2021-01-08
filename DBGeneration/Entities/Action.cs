using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("Action")]
    public class Action
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string ActionName { set; get; }
        public string Code { set; get; }
    }
}
