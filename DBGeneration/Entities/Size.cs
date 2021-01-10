using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration.Entities
{
    [Table("Size")]
    public class Size
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }

        public virtual ICollection<ProductQuantity> ProductQuantities { set; get; }
        public virtual ICollection<BillDetail> BillDetails { set; get; }
    }
}
