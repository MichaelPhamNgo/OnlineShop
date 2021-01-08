using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class RoleConfigurations : EntityTypeConfiguration<Role>
    {
        public RoleConfigurations()
        {        
            this.Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);            
            this.Property(p => p.Name).HasMaxLength(50);            
        }
    }
}
