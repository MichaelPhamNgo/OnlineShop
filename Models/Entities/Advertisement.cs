using Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Models.Entities
{
    [Table("Advertisement")]
    public class Advertisement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { set; get; }

        [Required]
        [MaxLength(250)]
        public string Name { set; get; }

        [MaxLength(250)]
        public string Description { set; get; }

        [MaxLength(250)]
        public string Image { set; get; }

        [MaxLength(250)]
        public string Url { set; get; }

        [ForeignKey("AdvertisementPosition")]
        public long? PostionId { set; get; }
                
        [Range(0, int.MaxValue)]
        public int? SortOrder { set; get; }
        
        public DateTime? DateCreated { set; get; }        
        public DateTime? DateModified { set; get; }        
        public Status? Status { set; get; }

        public virtual AdvertisementPosition AdvertisementPosition { set; get; }

    }
}
