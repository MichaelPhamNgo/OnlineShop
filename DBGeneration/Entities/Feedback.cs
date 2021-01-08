using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string MetaKeywords { set; get; }
        public string Detail { set; get; }
        public DateTime? CreatedDate { set; get; }
        public Status Status { set; get; }
    }
}
