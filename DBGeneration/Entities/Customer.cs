using DBGeneration.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { set; get; }                        

        [Required]
        [MaxLength(256)]
        public string FirstName { set; get; }

        [Required]
        [MaxLength(256)]
        public string LastName { set; get; }

        [MaxLength(256)]
        public string MiddleName { set; get; }

        [Required]
        [MaxLength(250)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { set; get; }               

        [MaxLength(50)]
        public string Phone { set; get; }
        
        [MaxLength(256)]
        public string Address1 { set; get; }

        [MaxLength(256)]
        public string Address2 { set; get; }

        [MaxLength(100)]
        public string City { set; get; }

        [MaxLength(10)]
        public string ZipCode { set; get; }

        [MaxLength(10)]
        public string State { set; get; }
                        
        public Status Status { set; get; }
                
        public virtual ICollection<Bill> Bills { set; get; }
    }
}
