using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("BillDetail")]
    public class BillDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [ForeignKey("Bill")]
        public long BillId { set; get; }

        [ForeignKey("Product")]
        public long ProductId { set; get; }
                
        public int Quantity { set; get; } = 0;
        
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { set; get; }

        [ForeignKey("Color")]
        public long ColorId { set; get; }

        [ForeignKey("Size")]
        public long SizeId { set; get; }

        public virtual Bill Bill { set; get; }
        public virtual Product Product { set; get; }
        public virtual Color Color { set; get; }
        public virtual Size Size { set; get; }
    }
}
