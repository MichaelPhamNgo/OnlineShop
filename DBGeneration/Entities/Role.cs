using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]        
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Credential> Credentials { set; get; }
    }
}
