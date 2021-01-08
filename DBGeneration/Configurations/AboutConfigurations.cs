using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class AboutConfigurations : EntityTypeConfiguration<About>
    {
        public AboutConfigurations()
        {
            this.Property(a => a.AboutName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(a => a.AboutDescription)
                .HasMaxLength(500);

            this.Property(a => a.Detail)
                .HasColumnType("text");

            this.Property(a => a.Image)
                .HasMaxLength(250);

            this.Property(a => a.MetaTitle)
                .HasMaxLength(250)
                .IsUnicode(false);                

            this.Property(a => a.SeoTitle)
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(a => a.MetaKeywords)
                .HasMaxLength(250);

            this.Property(a => a.MetaDescription)
                .HasMaxLength(250);
        }
    }
}
