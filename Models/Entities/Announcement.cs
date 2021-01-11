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
                
        public DateTime? DateCreated { set; get; }        
        public DateTime? DateModified { set; get; }        
        public Status? Status { set; get; }

        public virtual ICollection<AnnouncementUser> AnnouncementUsers { set; get; }
    }
}
