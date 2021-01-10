using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("AdvertisementPage")]
    public class AdvertisementPage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string Code { set; get; }

        [Column(TypeName = "text")]
        public string Name { set; get; }        
    }
}
