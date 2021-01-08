using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class CategoryConfigurations : EntityTypeConfiguration<Category>
    {
        public CategoryConfigurations()
        {
            this.Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(a => a.CategoryDescription)
                .HasMaxLength(500);

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
