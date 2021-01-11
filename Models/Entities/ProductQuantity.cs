using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("ProductQuantity")]
    public class ProductQuantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
                
        [ForeignKey("Product")]
        public long ProductId { set; get; }
                
        [ForeignKey("Size")]
        public long SizeId { set; get; }
                
        [ForeignKey("Color")]
        public long ColorId { set; get; }
                
        public int? Quantity { set; get; }

        public virtual Product Product { set; get; }
        public virtual Size Size { set; get; }
        public virtual Color Color { set; get; }
    }
}
