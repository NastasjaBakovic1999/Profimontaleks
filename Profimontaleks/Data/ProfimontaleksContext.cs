using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Profimontaleks.Data.Configuration;

namespace Profimontaleks.Data
{
    public class ProfimontaleksContext : DbContext
    {
        public DbSet<Phase> Phases { get; set; }
        public DbSet<PhaseStatus> PhaseStatuses { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCardboard> ProductCardboards { get; set; }
        public DbSet<ProductCardboardPhase> ProductCardboardPhases { get; set; }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=Profimontaleks;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCardboardPhase>(pcp =>
            {
                pcp.HasKey(pcp => new { pcp.PhaseId, pcp.PCCNumber });
                pcp.HasOne(a => a.ProductCardboard)
                    .WithMany(b => b.Phases);
            });

            modelBuilder.Entity<PhaseStatus>()
                .HasMany(ps => ps.Phases)
                .WithOne(p => p.Status)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductType>()
                .HasMany(pt => pt.Products)
                .WithOne(p => p.Type)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Worker>(w =>
            {
                w.HasKey(w => new { w.JMBG });
                w.HasOne(a => a.Position);
            });

            modelBuilder.Entity<WorkerStatus>()
                .HasMany(ws => ws.Workers)
                .WithOne(w => w.Status)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Position>()
                .HasMany(ws => ws.Workers)
                .WithOne(w => w.Position)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.ApplyConfiguration(new PhaseConfiguration());
            modelBuilder.ApplyConfiguration(new PhaseStatusConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCardboardConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCardboardPhaseConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerStatusConfiguration());

            Seed(modelBuilder);
        }

        private void Seed(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Phase>().HasData(
                new Phase { Id = 1, Description = "Secenje i drenaza" },
                new Phase { Id = 2, Description = "Celicno ojacavanje" },
                new Phase { Id = 3, Description = "Varenje uglova" },
                new Phase { Id = 4, Description = "Ciscenje i okivanje" },
                new Phase { Id = 5, Description = "Sklapanje proizvoda" }
            );

            modelBuilder.Entity<PhaseStatus>().HasData(
                new PhaseStatus { Id = 1, Description = "Zapoceto" },
                new PhaseStatus { Id = 2, Description = "U toku" },
                new PhaseStatus { Id = 3, Description = "Na cekanju" },
                new PhaseStatus { Id = 4, Description = "Otkazano" },
                new PhaseStatus { Id = 5, Description = "Zavrseno" }
            );

            modelBuilder.Entity<Position>().HasData(
               new Position { Id = 1, Description = "Secenje" },
               new Position { Id = 2, Description = "Brusenje" },
               new Position { Id = 3, Description = "Varenje" },
               new Position { Id = 4, Description = "Ciscenje" },
               new Position { Id = 5, Description = "Sklapanje" },
               new Position { Id = 6, Description = "Pakovanje" },
               new Position { Id = 7, Description = "Prijem" },
               new Position { Id = 8, Description = "Razvozenje" },
               new Position { Id = 9, Description = "Administracija" },
               new Position { Id = 10, Description = "Menadzment 1. nivoa" },
               new Position { Id = 11, Description = "Menadzment 2. nivoa" },
               new Position { Id = 12, Description = "Menadzment 3. nivoa" },
               new Position { Id = 13, Description = "Utovar" }
           );

            modelBuilder.Entity<WorkerStatus>().HasData(
               new WorkerStatus { Id = 1, Description = "Privremeno" },
               new WorkerStatus { Id = 2, Description = "Za stalno" },
               new WorkerStatus { Id = 3, Description = "Praksa" },
               new WorkerStatus { Id = 4, Description = "Pripravnistvo" },
               new WorkerStatus { Id = 5, Description = "Zamena" }
           );

            modelBuilder.Entity<ProductType>().HasData(
             new ProductType { Id = 1, Description = "Jednokrilni PVC prozor" },
             new ProductType { Id = 2, Description = "Dvokrilni PVC prozor" },
             new ProductType { Id = 3, Description = "Jednokrilni ALU prozor" },
             new ProductType { Id = 4, Description = "Dvokrilni ALU prozor" },
             new ProductType { Id = 5, Description = "Sobna PVC vrata" },
             new ProductType { Id = 6, Description = "Sobna ALU vrata" },
             new ProductType { Id = 7, Description = "PVC ulazna vrata Trocal 70", Colour = "Braon" },
             new ProductType { Id = 8, Description = "PVC ulazna vrata Trocal 76", Colour = "Crna" },
             new ProductType { Id = 9, Description = "PVC ulazna vrata Trocal 88", Colour = "Bela"},
             new ProductType { Id = 10, Description = "ALU ulazna vrata ETEM E-45", Colour="Bordo" },
             new ProductType { Id = 11, Description = "ALU ulazna vrata ALUMIL 60", Colour = "Braon" },
             new ProductType { Id = 12, Description = "Rolo komarnik" },
             new ProductType { Id = 13, Description = "Fiksni komarnik" },
             new ProductType { Id = 14, Description = "Americki komarnik" },
             new ProductType { Id = 15, Description = "Plisirani komarnik" },
             new ProductType { Id = 16, Description = "Venecijaner 25mm" },
             new ProductType { Id = 17, Description = "Venecijaner 16mm" },
             new ProductType { Id = 18, Description = "Venecijaner 16x25mm" },
             new ProductType { Id = 19, Description = "Venecijaner 50mm" },
             new ProductType { Id = 20, Description = "Okapnica" },
             new ProductType { Id = 21, Description = "Podprozorska daska" },
             new ProductType { Id = 22, Description = "ALU roletne" },
             new ProductType { Id = 23, Description = "PVC roletne" }
         );

            modelBuilder.Entity<Product>().HasData(
             new Product { Id = 1, ProductTypeId = 1, Height = 80, Length= 49, Weight = 2.2, GlassThickness = 0.18 },
             new Product { Id = 2, ProductTypeId = 2, Height = 80, Length = 98, Weight = 4.5, GlassThickness = 0.18 },
             new Product { Id = 3, ProductTypeId = 3, Height = 70, Length = 49, Weight = 2.2, GlassThickness = 0.18 },
             new Product { Id = 4, ProductTypeId = 2, Height = 70, Length = 98, Weight = 4.5, GlassThickness = 0.18 },
             new Product { Id = 5, ProductTypeId = 6, Height = 130, Length = 102, Weight = 22 },
             new Product { Id = 6, ProductTypeId = 7, Height = 133, Length = 109, Weight = 23 },
             new Product { Id = 7, ProductTypeId = 6, Height = 130, Length = 94, Weight = 20 },
             new Product { Id = 8, ProductTypeId = 12, Height = 80, Length = 104, Weight = 6.3},
             new Product { Id = 9, ProductTypeId = 12, Height = 110, Length = 104, Weight = 7.1 },
             new Product { Id = 10, ProductTypeId = 12, Height = 80, Length = 49, Weight = 4.6 }
         );
        }
    }
}
