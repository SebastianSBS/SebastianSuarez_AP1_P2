using Microsoft.EntityFrameworkCore;
using SebastianSuarez_AP1_P2.Models;

namespace SebastianSuarez_AP1_P2.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
         : base(options) { }

        public DbSet<Combos> Combo { get; set; }
        public DbSet<CombosDetalle> ComboDetalle { get; set; }

        public DbSet<Articulos> Articulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Combos>().HasData
            (
                new Combos
                {
                    ComboId = 1,
                    Descripcion = "Combo Gama ultra",
                },

                new Combos
                {
                    ComboId = 2,
                    Descripcion = "Combo Gama alta",

                },

                new Combos
                {
                    ComboId = 3,
                    Descripcion = "Combo Gama media",

                },

                new Combos
                {
                    ComboId = 4,
                    Descripcion = "Combo Gama baja",

                }
            );

            modelBuilder.Entity<Articulos>().HasData
            (
                  new Articulos
                  {
                      ArticuloId = 1,
                      Descripcion = "Mouse USB o PS2",
                      Costo = 700,
                      Precio = 800,
                      Existencia = 15,
                  },

                  new Articulos
                  {
                      ArticuloId = 2,
                      Descripcion = "Monitor 17''",
                      Costo = 7000,
                      Precio = 7500,
                      Existencia = 6,
                  },

                  new Articulos
                  {
                      ArticuloId = 3,
                      Descripcion = "Teclado USB o PS2",
                      Costo = 2000,
                      Precio = 2050,
                      Existencia = 8,
                  },

                  new Articulos
                  {
                      ArticuloId = 4,
                      Descripcion = "Tarjeta de video",
                      Costo = 35000,
                      Precio = 38000,
                      Existencia = 20,
                  },

                  new Articulos
                  {
                      ArticuloId = 5,
                      Descripcion = "Memoria RAM",
                      Costo = 1500,
                      Precio = 1800,
                      Existencia = 50,
                  },

                  new Articulos
                  {
                      ArticuloId = 6,
                      Descripcion = "Procesador",
                      Costo = 3500,
                      Precio = 3000,
                      Existencia = 15,
                  }
            );
        }

    }
}
