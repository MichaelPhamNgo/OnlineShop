using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class FeedbackConfigurations : EntityTypeConfiguration<Feedback>
    {
        public FeedbackConfigurations()
        {
            this.Property(f => f.Name)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(f => f.Phone)
                .HasMaxLength(50);

            this.Property(f => f.Email)
                .HasMaxLength(50);

            this.Property(f => f.Address)
                .HasMaxLength(50);

            this.Property(f => f.MetaKeywords)
                .HasMaxLength(250);

            this.Property(f => f.Detail)
                .HasMaxLength(500);

            this.Property(f => f.MetaKeywords)
                .HasMaxLength(250);
        }
    }
}
