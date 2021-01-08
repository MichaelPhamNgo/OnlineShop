using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class SystemConfigConfigurations : EntityTypeConfiguration<SystemConfig>
    {
        public SystemConfigConfigurations()
        {        
            this.Property(p => p.SystemConfigName)
                .IsRequired()
                .HasMaxLength(50);            
            this.Property(p => p.Type).HasMaxLength(50);
            this.Property(p => p.Value).HasMaxLength(250);
        }
    }
}
