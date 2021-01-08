using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class ContactConfigurations : EntityTypeConfiguration<Contact>
    {
        public ContactConfigurations()
        {            
            this.Property(c => c.Detail)
                .HasColumnType("text");
        }
    }
}
