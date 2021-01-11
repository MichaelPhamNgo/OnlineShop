using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("WholePrice")]
    public class WholePrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
                
        [ForeignKey("Product")]
        public long ProductId { set; get; }
                
        public int? FromQuantity { set; get; }
        public int? ToQuantity { set; get; }

        [DataType("decimal(18, 2)")]
        public decimal? Price { set; get; }

        public virtual Product Product { set; get; }
    }
}
