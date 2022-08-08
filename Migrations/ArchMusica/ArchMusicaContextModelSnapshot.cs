﻿// <auto-generated />
using System;
using AppV1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppV1.Migrations.ArchMusica
{
    [DbContext(typeof(ArchMusicaContext))]
    partial class ArchMusicaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("AppV1.Models.HistorialBusquedas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Peticion")
                        .HasColumnType("integer");

                    b.Property<int?>("PeticionID")
                        .HasColumnType("integer");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PeticionID");

                    b.ToTable("HistorialBusquedas");
                });

            modelBuilder.Entity("AppV1.Models.Peticion", b =>
                {
                    b.Property<int>("PeticionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Asunto")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("EmailEmisor")
                        .HasColumnType("text");

                    b.Property<string>("Emisor")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("text");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("PeticionID");

                    b.ToTable("Peticiones");
                });

            modelBuilder.Entity("AppV1.Models.HistorialBusquedas", b =>
                {
                    b.HasOne("AppV1.Models.Peticion", null)
                        .WithMany("HistorialBusquedas")
                        .HasForeignKey("PeticionID");
                });

            modelBuilder.Entity("AppV1.Models.Peticion", b =>
                {
                    b.Navigation("HistorialBusquedas");
                });
#pragma warning restore 612, 618
        }
    }
}
