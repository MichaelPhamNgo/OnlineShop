using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration.Entities
{
    [Table("BlogTag")]
    public class BlogTag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [ForeignKey("Blog")]
        public long BlogId { set; get; }

        [ForeignKey("Tag")]
        public long TagId { set; get; }

        public virtual Blog Blog { set; get; }
        public virtual Tag Tag { set; get; }
    }
}
