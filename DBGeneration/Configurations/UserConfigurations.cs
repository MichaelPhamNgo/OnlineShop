using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class UserConfigurations : EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {        
            this.Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(50);            
            this.Property(p => p.Password).HasMaxLength(250);
            this.Property(p => p.Salt).HasMaxLength(250);
            this.Property(p => p.FirstName).HasMaxLength(50);
            this.Property(p => p.LastName).HasMaxLength(50);
            this.Property(p => p.MiddleName).HasMaxLength(50);
            this.Property(p => p.Email).HasMaxLength(250);
            this.Property(p => p.Address1).HasMaxLength(250);
            this.Property(p => p.Address2).HasMaxLength(250);
            this.Property(p => p.City).HasMaxLength(50);
            this.Property(p => p.ZipCode).HasMaxLength(50);
            this.Property(p => p.GroupId).HasMaxLength(20).IsUnicode(false);
        }
    }
}
