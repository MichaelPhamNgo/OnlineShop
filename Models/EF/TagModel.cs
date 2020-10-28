using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EF
{
    public class TagModel
    {
        public long Id { get; set; }
        public string Name { get; set; }        
        public DateTime? CreatedDate { get; set; }
        public string Creator { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Modifier { get; set; }
        public bool Status { get; set; }        
        public int? DisplayOrder { get; set; }
    }
}
