using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class PhaseStatusConfiguration : IEntityTypeConfiguration<PhaseStatus>
    {
        public void Configure(EntityTypeBuilder<PhaseStatus> builder)
        {
            builder.ToTable("PhaseStatus");

            builder.Property(ps => ps.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(ps => ps.Description)
               .HasColumnName("Description")
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(40);

        }
    }
}
