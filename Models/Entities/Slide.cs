using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entities
{
    [Table("Slide")]
    public class Slide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
                
        [MaxLength(256)]
        public string Description { set; get; }

        [MaxLength(256)]
        public string Image { set; get; }

        [MaxLength(256)]
        public string Url { set; get; }

        public int? SortOrder { set; get; }
                
        public Status? Status { set; get; }

        [Column(TypeName = "text")]
        public string Content { set; get; }
                
        [MaxLength(25)]
        public string GroupAlias { set; get; }
    }
}
