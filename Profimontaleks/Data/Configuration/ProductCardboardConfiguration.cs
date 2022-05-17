using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class ProductCardboardConfiguration : IEntityTypeConfiguration<ProductCardboard>
    {
        public void Configure(EntityTypeBuilder<ProductCardboard> builder)
        {
            builder.ToTable("ProductCardboard");

            builder.Property(p => p.PCCNumber)
              .HasColumnName("PCCNumber")
              .IsRequired();

            builder.HasKey(p => p.PCCNumber);

            builder.Property(p => p.ProductId)
              .HasColumnName("ProductId")
              .IsRequired();
        }
    }
}
