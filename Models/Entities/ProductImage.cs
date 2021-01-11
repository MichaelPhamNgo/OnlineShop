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
    [Table("ProductImage")]
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
                
        [ForeignKey("Product")]
        public long ProductId { set; get; }

        [MaxLength(256)]
        public string Path { set; get; }

        [MaxLength(256)]
        public string Caption { set; get; }

        public virtual Product Product { set; get; }
    }
}
