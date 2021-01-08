using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class ActionConfigurations : EntityTypeConfiguration<DBGeneration.Entities.Action>
    {
        public ActionConfigurations()
        {
            this.Property(a => a.ActionName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(a => a.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
