﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SebastianSuarez_AP1_P2.DAL;

#nullable disable

namespace SebastianSuarez_AP1_P2.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SebastianSuarez_AP1_P2.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 700,
                            Descripcion = "Mouse USB o PS2",
                            Existencia = 15,
                            Precio = 800
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 7000,
                            Descripcion = "Monitor 17''",
                            Existencia = 6,
                            Precio = 7500
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 2000,
                            Descripcion = "Teclado USB o PS2",
                            Existencia = 8,
                            Precio = 2050
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 35000,
                            Descripcion = "Tarjeta de video",
                            Existencia = 20,
                            Precio = 38000
                        },
                        new
                        {
                            ArticuloId = 5,
                            Costo = 1500,
                            Descripcion = "Memoria RAM",
                            Existencia = 50,
                            Precio = 1800
                        },
                        new
                        {
                            ArticuloId = 6,
                            Costo = 3500,
                            Descripcion = "Procesador",
                            Existencia = 15,
                            Precio = 3000
                        });
                });

            modelBuilder.Entity("SebastianSuarez_AP1_P2.Models.Combos", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<bool>("Vendido")
                        .HasColumnType("bit");

                    b.HasKey("ComboId");

                    b.ToTable("Combo");

                    b.HasData(
                        new
                        {
                            ComboId = 1,
                            Descripcion = "Combo Gama ultra",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Precio = 0,
                            Vendido = false
                        },
                        new
                        {
                            ComboId = 2,
                            Descripcion = "Combo Gama alta",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Precio = 0,
                            Vendido = false
                        },
                        new
                        {
                            ComboId = 3,
                            Descripcion = "Combo Gama media",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Precio = 0,
                            Vendido = false
                        },
                        new
                        {
                            ComboId = 4,
                            Descripcion = "Combo Gama baja",
                            Fecha = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Precio = 0,
                            Vendido = false
                        });
                });

            modelBuilder.Entity("SebastianSuarez_AP1_P2.Models.CombosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<int>("Costo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("ComboId");

                    b.ToTable("ComboDetalle");
                });

            modelBuilder.Entity("SebastianSuarez_AP1_P2.Models.CombosDetalle", b =>
                {
                    b.HasOne("SebastianSuarez_AP1_P2.Models.Articulos", "Articulos")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SebastianSuarez_AP1_P2.Models.Combos", "Combos")
                        .WithMany("ComboDetalle")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulos");

                    b.Navigation("Combos");
                });

            modelBuilder.Entity("SebastianSuarez_AP1_P2.Models.Combos", b =>
                {
                    b.Navigation("ComboDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
