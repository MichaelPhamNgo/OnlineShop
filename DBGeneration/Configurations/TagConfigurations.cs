using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class TagConfigurations : EntityTypeConfiguration<Tag>
    {
        public TagConfigurations()
        {        
            this.Property(p => p.TagName)
                .IsRequired()
                .HasMaxLength(50);            
            this.Property(p => p.TagDescription).HasMaxLength(250);            
        }
    }
}
