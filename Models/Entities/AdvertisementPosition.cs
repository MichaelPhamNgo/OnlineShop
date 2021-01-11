using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    [Table("AdvertisementPosition")]
    public class AdvertisementPosition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [ForeignKey("Page")]
        public long PageId { set; get; }

        [Required]
        [MaxLength(250)]
        public string Name { set; get; }

        public virtual Page Page { set; get; }
        public virtual ICollection<Advertisement> Advertisements { set; get; }
    }
}
