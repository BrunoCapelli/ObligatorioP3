﻿// <auto-generated />
using System;
using Data_Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data_Access.Migrations
{
    [DbContext(typeof(MiContexto))]
    [Migration("20230930195413_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Amenaza", b =>
                {
                    b.Property<int>("AmenazaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AmenazaId"));

                    b.Property<int>("EcosistemaMarinoId")
                        .HasColumnType("int");

                    b.Property<int>("GradoPeligrosidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AmenazaId");

                    b.HasIndex("EcosistemaMarinoId");

                    b.ToTable("Amenazas");
                });

            modelBuilder.Entity("Domain.Entities.Audit", b =>
                {
                    b.Property<int>("AuditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuditId"));

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEntidad")
                        .HasColumnType("int");

                    b.Property<string>("TipoEntidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuditId");

                    b.ToTable("Audits");
                });

            modelBuilder.Entity("Domain.Entities.EcosistemaMarino", b =>
                {
                    b.Property<int>("EcosistemaMarinoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EcosistemaMarinoId"));

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<int>("EstadoConservacionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<int>("UbicacionGeograficaUbiGeograficaId")
                        .HasColumnType("int");

                    b.HasKey("EcosistemaMarinoId");

                    b.HasIndex("EstadoConservacionId");

                    b.HasIndex("PaisId");

                    b.HasIndex("UbicacionGeograficaUbiGeograficaId");

                    b.ToTable("Ecosistemas");
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.Property<int>("EspecieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EspecieId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoConservacionId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCientifico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreVulgar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PesoMax")
                        .HasColumnType("float");

                    b.Property<double>("PesoMin")
                        .HasColumnType("float");

                    b.HasKey("EspecieId");

                    b.HasIndex("EstadoConservacionId");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("Domain.Entities.EstadoConservacion", b =>
                {
                    b.Property<int>("EstadoConservacionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoConservacionId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("EstadoConservacionId");

                    b.ToTable("EstadosCo");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<int>("PaisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaisId"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaisId");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Domain.Entities.UbiGeografica", b =>
                {
                    b.Property<int>("UbiGeograficaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UbiGeograficaId"));

                    b.Property<int>("GradoPeligro")
                        .HasColumnType("int");

                    b.Property<double>("Latitud")
                        .HasColumnType("float");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.HasKey("UbiGeograficaId");

                    b.ToTable("UbisGeograficas");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("Domain.Entities.Amenaza", b =>
                {
                    b.HasOne("Domain.Entities.EcosistemaMarino", null)
                        .WithMany("Amenazas")
                        .HasForeignKey("EcosistemaMarinoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.EcosistemaMarino", b =>
                {
                    b.HasOne("Domain.Entities.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("EstadoConservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pais", null)
                        .WithMany("ecosistemaMarinos")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.UbiGeografica", "UbicacionGeografica")
                        .WithMany()
                        .HasForeignKey("UbicacionGeograficaUbiGeograficaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoConservacion");

                    b.Navigation("UbicacionGeografica");
                });

            modelBuilder.Entity("Domain.Entities.Especie", b =>
                {
                    b.HasOne("Domain.Entities.EstadoConservacion", "EstadoConservacion")
                        .WithMany()
                        .HasForeignKey("EstadoConservacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoConservacion");
                });

            modelBuilder.Entity("Domain.Entities.EcosistemaMarino", b =>
                {
                    b.Navigation("Amenazas");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Navigation("ecosistemaMarinos");
                });
#pragma warning restore 612, 618
        }
    }
}
