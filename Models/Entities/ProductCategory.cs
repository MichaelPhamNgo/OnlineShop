using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("ProductCategory")]
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(2000)]
        public string Name { set; get; }

        [MaxLength(2000)]
        public string Description { set; get; }
        
        public long? ParentId { set; get; }
                
        public int? HomeOrder { set; get; }

        [MaxLength(2000)]
        public string Image { set; get; }   
        
        public int? SortOrder { set; get; }
                
        public DateTime? DateCreated { set; get; }        
        public DateTime? DateModified { set; get; }
        public Status? Status { set; get; }

        [MaxLength(256)]
        public string SeoPageTitle { set; get; }
        [MaxLength(256)]
        public string SeoAlias { set; get; }
        [MaxLength(256)]
        public string SeoKeywords { set; get; }
        [MaxLength(256)]
        public string SeoDescription { set; get; }

        public virtual ICollection<Product> Products { set; get; }
    }
}
