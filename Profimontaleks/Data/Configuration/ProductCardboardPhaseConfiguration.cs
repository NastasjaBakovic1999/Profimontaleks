using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class ProductCardboardPhaseConfiguration : IEntityTypeConfiguration<ProductCardboardPhase>
    {
        public void Configure(EntityTypeBuilder<ProductCardboardPhase> builder)
        {
            builder.ToTable("ProductCardboardPhase");

            builder.Property(e => e.PCCNumber)
                .HasColumnName("ProductCardboardId");

            builder.Property(e => e.PhaseId)
                .HasColumnName("PhaseId");

            builder.Property(p => p.StatusId)
                 .HasColumnName("StatusId")
                 .IsRequired();
        }
    }
}
