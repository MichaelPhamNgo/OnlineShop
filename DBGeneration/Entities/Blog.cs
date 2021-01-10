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
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
                
        [MaxLength(256)]
        public string Image { set; get; }
        
        [MaxLength(500)]
        public string Description { set; get; }

        [Column(TypeName = "text")]
        public string Content { set; get; }
                
        public bool HomeFlag { set; get; }
        public bool HotFlag { set; get; }        
        public int ViewCount { set; get; }

        [MaxLength(2000)]
        public string Tags { set; get; }

        
        public DateTime DateCreated { set; get; }        
        public DateTime DateModified { set; get; }        
        public Status Status { set; get; }

        [MaxLength(256)]
        public string SeoPageTitle { set; get; }
        [MaxLength(256)]
        public string SeoAlias { set; get; }
        [MaxLength(256)]
        public string SeoKeywords { set; get; }
        [MaxLength(256)]
        public string SeoDescription { set; get; }

        public virtual ICollection<BlogTag> BlogTags { set; get; }
    }
}
