using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class StateConfigurations : EntityTypeConfiguration<State>
    {
        public StateConfigurations()
        {        
            this.Property(p => p.StateName)
                .IsRequired()
                .HasMaxLength(50);            
            this.Property(p => p.StateDescription).HasMaxLength(250);
        }
    }
}
