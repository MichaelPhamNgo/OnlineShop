using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("Tag")]
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
                
        [Required]
        [StringLength(50)]        
        public string Name { set; get; }
                
        [StringLength(50)]        
        public string Type { set; get; }

        public virtual ICollection<ProductTag> ProductTags { set; get; }
        public virtual ICollection<BlogTag> BlogTags { set; get; }
    }
}
