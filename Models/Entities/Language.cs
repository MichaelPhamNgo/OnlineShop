using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entities
{
    [Table("Language")]
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(128)]
        [Column(TypeName = "varchar")]        
        public string Code { set; get; }

        [Required]
        [MaxLength(128)]
        [Column(TypeName = "varchar")]
        public string Name { set; get; }
                
        public bool? isDefault { set; get; }

        [MaxLength(2000)]        
        public string Resources { set; get; }
                
        public Status? Status { set; get; }
    }
}
