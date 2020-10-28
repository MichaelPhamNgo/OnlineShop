using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class CategoryModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string SeoTitle { get; set; }        
        public string MetaKeywords { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public DateTime? CreatedDate { get; set; }        
        public string Creator { get; set; }        
        public DateTime? ModifiedDate { get; set; }
        public string Modifier { get; set; }        
        public bool Status { get; set; }
        public bool? ShowOnHome { get; set; }
        public long? ParentId { get; set; }
        public string CategoryParent { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
