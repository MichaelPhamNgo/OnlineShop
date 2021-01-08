using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class MenuConfigurations : EntityTypeConfiguration<Menu>
    {
        public MenuConfigurations()
        {        
            this.Property(f => f.Text).HasMaxLength(250);
            this.Property(f => f.Link).HasMaxLength(250);
            this.Property(f => f.Target).HasMaxLength(50);
        }
    }
}
