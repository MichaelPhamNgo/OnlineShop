using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class FunctionConfigurations : EntityTypeConfiguration<Function>
    {
        public FunctionConfigurations()
        {
            this.Property(f => f.IconCss)
                .HasMaxLength(50)
                .IsUnicode(false);
            this.Property(f => f.FunctionName).HasMaxLength(50);
        }
    }
}
