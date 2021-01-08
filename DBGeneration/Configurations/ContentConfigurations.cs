using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class ContentConfigurations : EntityTypeConfiguration<Content>
    {
        public ContentConfigurations()
        {
            this.Property(c => c.ContentName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(c => c.ContentDescription)
                .HasMaxLength(500);

            this.Property(c => c.Image)
                .HasMaxLength(250);

            this.Property(c => c.Detail)
                .HasColumnType("text");

            this.Property(c => c.MetaTitle)
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(c => c.SeoTitle)
                .HasMaxLength(250)
                .IsUnicode(false);

            this.Property(c => c.MetaKeywords)
                .HasMaxLength(250);

            this.Property(c => c.MetaDescription)
                .HasMaxLength(250);

            this.Property(c => c.Tags)
                .HasMaxLength(250);
        }
    }
}
