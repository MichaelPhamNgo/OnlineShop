﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DBGeneration.Entities
{
    [Table("UserGroup")]
    public class UserGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(250)]
        public string Name { set; get; }

        public virtual ICollection<User> Users { set; get; }
        public virtual ICollection<Credential> Credentials { set; get; }
    }
}
