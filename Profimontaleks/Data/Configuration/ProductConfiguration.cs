using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.Property(p => p.Weight)
                .HasColumnName("Weight")
                .HasColumnType("decimal");

            builder.Property(p => p.Height)
                .HasColumnName("Height")
                .HasColumnType("decimal");

            builder.Property(p => p.Length)
                .HasColumnName("Length")
                .HasColumnType("decimal");

            builder.Property(p => p.GlassThickness)
                .HasColumnName("GlassThickness")
                .HasColumnType("decimal");

            builder.Property(p => p.ProductTypeId)
            .HasColumnName("ProductTypeId")
            .IsRequired();

        }
    }
}
