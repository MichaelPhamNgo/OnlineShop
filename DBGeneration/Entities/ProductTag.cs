using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("ProductTag")]
    public class ProductTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
                
        [ForeignKey("Product")]
        public long ProductId { set; get; }
                
        [ForeignKey("Tag")]
        public long TagId { set; get; }

        public virtual Product Product { set; get; }
        public virtual Tag Tag { set; get; }
    }
}
