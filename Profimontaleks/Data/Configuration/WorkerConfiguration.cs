using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data.Configuration
{
    public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
    {
        public void Configure(EntityTypeBuilder<Worker> builder)
        {
            builder.ToTable("Worker");

            builder.HasKey(w => new {w.Id, w.JMBG});

            builder.Property(w => w.WorkerStatusId)
             .HasColumnName("WorkerStatusId")
             .IsRequired()
             .HasColumnType("int");

            builder.Property(w => w.PositionId)
                .HasColumnName("PositionId")
                .IsRequired()
                .HasColumnType("int");

            builder.Property(w => w.NameAndSurname)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(p => p.Coefficient)
               .HasColumnName("Coefficient")
               .HasColumnType("decimal");
        }
    }
}
