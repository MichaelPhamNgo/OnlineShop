using DBGeneration.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBGeneration
{
    public class ProductConfigurations : EntityTypeConfiguration<Product>
    {
        public ProductConfigurations()
        {        
            this.Property(p => p.ProductCode)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);
            this.Property(p => p.ProductName).HasMaxLength(250);
            this.Property(p => p.Image).HasMaxLength(50);
            this.Property(c => c.MoreImages)
                .HasMaxLength(250)
                .HasColumnType("text");
            this.Property(c => c.Detail)                
                .HasColumnType("text");
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
