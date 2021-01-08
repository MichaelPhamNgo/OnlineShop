using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class UserGroupConfigurations : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupConfigurations()
        {        
            this.Property(p => p.Id)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);            
            this.Property(p => p.Name).HasMaxLength(50);            
        }
    }
}
