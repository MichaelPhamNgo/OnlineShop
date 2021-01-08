using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class SlideConfigurations : EntityTypeConfiguration<Slide>
    {
        public SlideConfigurations()
        {        
            this.Property(p => p.Image)
                .IsRequired()
                .HasMaxLength(250);            
            this.Property(p => p.Description).HasMaxLength(250);
            this.Property(p => p.Sale).HasMaxLength(250);
            this.Property(p => p.Link).HasMaxLength(250);
        }
    }
}
