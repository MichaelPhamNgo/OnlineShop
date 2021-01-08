using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class ProductCategoryConfigurations : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfigurations()
        {
            this.Property(p => p.ProductCategoryName)
                .IsRequired()
                .HasMaxLength(250);
            this.Property(p => p.MetaTitle)                
                .HasMaxLength(250)
                .IsUnicode(false);
            this.Property(p => p.SeoTitle)                
                .HasMaxLength(250)
                .IsUnicode(false);
            this.Property(p => p.MetaKeywords).HasMaxLength(250);
            this.Property(p => p.MetaDescription).HasMaxLength(250);
        }
    }
}
