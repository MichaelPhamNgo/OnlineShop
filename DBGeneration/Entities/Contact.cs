﻿using DBGeneration.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBGeneration.Entities
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }
        
        [Required]
        [MaxLength(256)]
        public string Code { set; get; }

        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
                
        [MaxLength(50)]
        public string Phone { set; get; }

        [MaxLength(256)]
        public string Website { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        [MaxLength(2000)]
        public string Other { set; get; }

        public float Lat { set; get; }
        public float Lng { set; get; }

        public Status Status { set; get; }
    }
}
