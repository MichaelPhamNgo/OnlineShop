using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(250)]
        public string Name { set; get; }

        [MaxLength(50)]
        public string Phone { set; get; }

        [Required]
        [MaxLength(250)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { set; get; }

        [MaxLength(500)]
        public string Message { set; get; }
                
        public DateTime? DateCreated { set; get; }        
        public DateTime? DateModified { set; get; }        
        public Status? Status { set; get; }
    }
}
