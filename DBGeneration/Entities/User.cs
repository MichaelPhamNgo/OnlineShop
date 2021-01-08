using DBGeneration.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Salt { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string MiddleName { set; get; }
        public string Email { set; get; }
        public bool? EmailConfirm { set; get; }
        public string Phone { set; get; }
        public DateTime? Birthday { set; get; }
        public string Address1 { set; get; }
        public string Address2 { set; get; }
        public string City { set; get; }
        public string ZipCode { set; get; }
        public long? StateId { set; get; }
        public DateTime? RegisteredDate { set; get; }
        public DateTime? LastLoginDate { set; get; }
        public Status Status { set; get; }
        public string GroupId { set; get; }
    }
}
