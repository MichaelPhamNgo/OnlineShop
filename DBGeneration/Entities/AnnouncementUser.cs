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
    [Table("AnnouncementUser")]
    public class AnnouncementUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [ForeignKey("Announcement")]
        public long AnnouncementId {set;get;}

        [ForeignKey("User")]
        public Guid UserId { set; get; }

        public bool HasRead { set; get;}

        public virtual Announcement Announcement { set; get; }
        public virtual User User { set; get; }
    }
}
