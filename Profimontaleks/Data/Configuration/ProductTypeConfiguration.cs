using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("ProductType");

            builder.Property(ps => ps.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(ps => ps.Description)
               .HasColumnName("Description")
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(40);

            builder.Property(ps => ps.Colour)
               .HasColumnName("Colour")
               .HasColumnType("varchar")
               .HasMaxLength(40);


        }
    }
}
