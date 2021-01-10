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
    [Table("Announcement")]
    public class Announcement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(250)]        
        public string Title { set; get; }

        [MaxLength(250)]
        public string Content { set; get; }

        [ForeignKey("User")]
        public Guid UserId { set; get; }
                
        public DateTime DateCreated { set; get; }        
        public DateTime DateModified { set; get; }        
        public Status Status { set; get; }

        public virtual User User { set; get; }
        public virtual ICollection<AnnouncementUser> AnnouncementUsers { set; get; }
    }
}
