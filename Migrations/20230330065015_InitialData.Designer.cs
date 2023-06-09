﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectef.Context;

#nullable disable

namespace minimal_api.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20230330065015_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("8ed0cfd3-74af-4b87-9284-e87f209c892d"),
                            Nombre = "Categoria 1",
                            Peso = 10
                        },
                        new
                        {
                            CategoriaId = new Guid("f2674df3-6801-42b5-9338-ec35da6cd307"),
                            Nombre = "Categoria 2",
                            Peso = 20
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("fb21f0db-e31b-4ed3-92fa-4687dcfcfdcf"),
                            CategoriaId = new Guid("8ed0cfd3-74af-4b87-9284-e87f209c892d"),
                            Descripcion = "tarea 1 ",
                            FechaCreacion = new DateTime(2023, 3, 30, 1, 50, 15, 594, DateTimeKind.Local).AddTicks(8023),
                            PrioridadTarea = 0,
                            Titulo = "Tarea 1 "
                        },
                        new
                        {
                            TareaId = new Guid("7f1fc391-32a1-4f0a-9958-488ae5c0ae43"),
                            CategoriaId = new Guid("f2674df3-6801-42b5-9338-ec35da6cd307"),
                            FechaCreacion = new DateTime(2023, 3, 30, 1, 50, 15, 594, DateTimeKind.Local).AddTicks(8038),
                            PrioridadTarea = 2,
                            Titulo = "Tarea 2"
                        });
                });

            modelBuilder.Entity("projectef.Models.Tarea", b =>
                {
                    b.HasOne("projectef.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("projectef.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
