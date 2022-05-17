using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class WorkerStatusConfiguration : IEntityTypeConfiguration<WorkerStatus>
    {
        public void Configure(EntityTypeBuilder<WorkerStatus> builder)
        {
            builder.ToTable("WorkerStatus");

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
