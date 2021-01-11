using Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("Function")]
    public class Function
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(256)]        
        public string Name { set; get; }

        [Required]
        [MaxLength(256)]
        public string URL { set; get; }
                
        public long? ParentId { set; get; }

        [MaxLength(256)]
        public string IconCss { set; get; }

        [Required]
        [Range(0, int.MaxValue)]
        public int? SortOrder { set; get; }

        [Required]
        public Status? Status { set; get; }
    }
}
