using Microsoft.EntityFrameworkCore;
using SebastianSuarez_AP1_P2.Models;

namespace SebastianSuarez_AP1_P2.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> Options) : base(Options) { }

        public DbSet<Combos> Combo { get; set; }
        public DbSet<CombosDetalle> combosDetalles { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Combo>().
             HasData(new List<Combo>() {
                 new Deudor(){DeudorId = 1, DeudorName= "Pedro" },
                 new Deudor(){DeudorId= 2, DeudorName = "Angel" },
                 new Deudor(){DeudorId= 3, DeudorName= "Diego"}
             });
         }*/
    }
}
