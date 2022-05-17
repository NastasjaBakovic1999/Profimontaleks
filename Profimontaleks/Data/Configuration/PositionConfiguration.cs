using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");

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
