using GelatoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GelatoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<RawMaterial> RawMaterials { get; set; }
        public DbSet<RawMaterialSupplier> RawMaterialSuppliers { get; set; }
        public DbSet<RawMaterialType> RawMaterialTypes { get; set; }
        public DbSet<BaseType> BaseTypes { get; set; }
        public DbSet<BaseRecipe> BaseRecipes { get; set; }
        public DbSet<GelatoRecipe> GelatoRecipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed Users
            modelBuilder.Entity<AppUser>()
                .HasData(
                    new AppUser { Id = 1, UserName = "Lucas", IsAdmin = true },
                    new AppUser { Id = 2, UserName = "Cid", IsAdmin = true },
                    new AppUser { Id = 3, UserName = "Suélen", IsAdmin = true }
                );

            // Seed Suppliers 
            modelBuilder.Entity<RawMaterialSupplier>()
                .HasData(
                    new RawMaterial { Id = 1, Name= "Outro" },
                    new RawMaterial { Id = 2, Name= "MEC3" },
                    new RawMaterial { Id = 3, Name= "PreGel" },
                    new RawMaterial { Id = 4, Name= "Fabbri" },
                    new RawMaterial { Id = 5, Name= "Callebaut" },
                    new RawMaterial { Id = 6, Name= "Lactobom" },
                    new RawMaterial { Id = 7, Name= "LAR Supermercado" },
                    new RawMaterial { Id = 8, Name= "Shopping do Sorveteiro" },
                    new RawMaterial { Id = 9, Name= "Destro" },
                    new RawMaterial { Id = 10, Name= "SanCor" },
                    new RawMaterial { Id = 11, Name= "LeiteSol La Serenissima" },
                    new RawMaterial { Id = 12, Name= "Apice Sul" },
                    new RawMaterial { Id = 13, Name= "Grings" },
                    new RawMaterial { Id = 14, Name= "PopHouse" },
                    new RawMaterial { Id = 15, Name= "Mayers" },
                    new RawMaterial { Id = 16, Name= "CeleroNacional" }
                );

            // Seed Raw Types
            modelBuilder.Entity<RawMaterialType>()
                .HasData(
                    new RawMaterialType { Id=1, Type="Pasta"},
                    new RawMaterialType { Id=2, Type="Variegato"},
                    new RawMaterialType { Id=3, Type="Pasta / Variegato"},
                    new RawMaterialType { Id=4, Type="Basica"},
                    new RawMaterialType { Id=5, Type="Basica / Variegato"},
                    new RawMaterialType { Id=6, Type="Fruta"}
                );

            // Seed Base Types
            modelBuilder.Entity<BaseType>()
                .HasData(
                new BaseType { Id=1, Name="Base Branca"},
                new BaseType { Id=2, Name="Base Caramello"}
                );
        }
    }
}
