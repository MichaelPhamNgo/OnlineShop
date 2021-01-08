using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("ContentTag")]
    public class ContentTag
    {
        [Key, Column(Order = 0)]
        public long ContentId { set; get; }

        [Key, Column(Order = 1)]
        [StringLength(50)]
        [DataType("varchar")]
        public string TagId { set; get; }
    }
}
