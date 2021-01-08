using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class CredentialConfigurations : EntityTypeConfiguration<Credential>
    {
        public CredentialConfigurations()
        {        
            this.Property(p => p.UserGroupId)                
                .HasMaxLength(20)
                .IsUnicode(false);            
            this.Property(p => p.RoleId)                
                .HasMaxLength(50)
                .IsUnicode(false);            
        }
    }
}
