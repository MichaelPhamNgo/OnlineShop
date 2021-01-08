using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class FooterConfigurations : EntityTypeConfiguration<Footer>
    {
        public FooterConfigurations()
        {
            this.Property(f => f.Detail).HasColumnType("text");
        }
    }
}
