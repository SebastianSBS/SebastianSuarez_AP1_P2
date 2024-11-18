using Microsoft.EntityFrameworkCore;
using SebastianSuarez_AP1_P2.Models;
using static Azure.Core.HttpHeader;

namespace SebastianSuarez_AP1_P2.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }
        public DbSet<Combos> Combo { get; set; }
        public DbSet<CombosDetalle> combosDetalles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Combos>().
            HasData(new List<Combos>() {
         new Combos(){ComboId=1, Descripcion= "Gama alta", Precio= 11400},
         new Combos(){ComboId=2, Descripcion= "Gama media", Precio= 9750},
         new Combos(){ComboId=3, Descripcion= "Gama baja", Precio= 4600}

            });
        }


    }
}
