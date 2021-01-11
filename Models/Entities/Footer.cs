using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entities
{
    [Table("Footer")]
    public class Footer
    {
        [Key]
        [StringLength(50)]
        [DataType("varchar")]
        public string Id { set; get; }

        [Required]
        [DataType("text")]
        public string Content { set; get; }        
    }
}
