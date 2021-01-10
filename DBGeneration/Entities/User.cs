using DBGeneration.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { set; get; }
                
        [Required]
        [MaxLength(50)]
        public string UserName { set; get; }

        [Required]
        [MinLength(6)]
        [MaxLength(256)]
        public string Password { set; get; }

        [Required]
        [MaxLength(256)]
        public string PasswordHash { set; get; }

        [Required]
        [MaxLength(256)]
        public string SecurityStamp { set; get; }

        [Required]
        [MaxLength(256)]
        public string FirstName { set; get; }

        [Required]
        [MaxLength(256)]
        public string LastName { set; get; }

        [MaxLength(256)]
        public string MiddleName { set; get; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { set; get; }

        public bool EmailConfirm { set; get; } = false;

        [MaxLength(50)]
        public string Phone { set; get; }

        public DateTime? Birthday { set; get; }

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

        [Required]
        public DateTime LastLogin { set; get; }

        [Required]
        public int LoginAttempt { set; get; } = 0;
        
        public Status Status { set; get; }

        [Required]
        [ForeignKey("UserGroup")]
        public long UserGroupId { set; get; }

        public virtual UserGroup UserGroup { set; get; }
        public virtual ICollection<Announcement> Announcements { set; get; }
        public virtual ICollection<AnnouncementUser> AnnouncementUsers { set; get; }
    }
}
