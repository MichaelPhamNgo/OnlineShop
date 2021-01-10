using DBGeneration.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration.Entities
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string CustomerName { set; get; }
                
        [MaxLength(256)]
        public string CustomerAddress { set; get; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { set; get; }

        
        [MaxLength(256)]
        public string CustomerMessage { set; get; }
        public int PaymentMethod { set; get; }
        public int BillStatus { set; get; }

        [ForeignKey("Customer")]
        public Guid CustomerId { set; get; }
        
        public DateTime DateCreated { set; get; }        
        public DateTime DateModified { set; get; }        
        public Status Status { set; get; }

        public virtual Customer Customer { set; get; }
        public virtual ICollection<BillDetail> BillDetails { set; get; }
    }
}
