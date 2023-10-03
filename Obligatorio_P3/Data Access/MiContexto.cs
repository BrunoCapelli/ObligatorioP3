using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access {
    public class MiContexto:DbContext{

        public DbSet<Amenaza> Amenazas { get; set; }

        public DbSet<Audit> Audits { get; set; }

        public DbSet<EcosistemaMarino> Ecosistemas { get; set; }
       
        /*public DbSet<EcosistemaMarinoEspecie> EcosistemaMarinosEspecies { get; set; }*/

        public DbSet<Especie> Especies { get; set; }

        public DbSet<EstadoConservacion> EstadosConservacion { get; set; }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<UbiGeografica> UbisGeograficas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public MiContexto(DbContextOptions options) : base(options) {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
           modelBuilder.Entity<Amenaza>().HasKey(a => a.AmenazaId);

           modelBuilder.Entity<Audit>().HasKey(a => a.AuditId);

            modelBuilder.Entity<EcosistemaMarino>().HasKey(em => em.EcosistemaMarinoId);

            modelBuilder.Entity<Especie>().HasKey(e => e.EspecieId);

            modelBuilder.Entity<EstadoConservacion>().HasKey(ec => ec.EstadoConservacionId);
            // modelBuilder.Entity<Pais>().HasKey(pais => pais.PaisId);
            // modelBuilder.Entity<UbiGeografica>().HasKey(ubi=>ubi.UbiGeograficaId);
            // modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioId);

            // relaciones
            modelBuilder.Entity<EcosistemaMarino>().HasMany(em => em.Amenazas).WithOne().HasForeignKey(a => a.EcosistemaMarinoId);
            modelBuilder.Entity<Pais>().HasMany(p => p.ecosistemaMarinos).WithOne().HasForeignKey(ec => ec.PaisId);

            /* modelBuilder.Entity<EcosistemaMarinoEspecie>()
                 .HasKey(ece => new {ece.EcosistemaMarinoId, ece.EspecieId});*/


            /*modelBuilder.Entity<EcosistemaMarinoEspecie>()
                .HasOne(ec => ec.EcosistemaMarino)
                .WithMany(e => e.EcosistemaMarinoEspecies)
                .HasForeignKey(ec => ec.EcosistemaMarinoId);

            modelBuilder.Entity<EcosistemaMarinoEspecie>()
                .HasOne(ec => ec.Especie)
                .WithMany(e => e.EcosistemasHabitados)
                .HasForeignKey(ec => ec.EspecieId);*/

           // modelBuilder.Entity<Especie>().HasOne(e => e.EstadoConservacion).WithOne().HasForeignKey(e => e.);

            modelBuilder.Entity<EcosistemaMarino>().HasMany(eC => eC.Especies).WithOne().HasForeignKey(e => e.EcosistemaMarinoId).OnDelete(DeleteBehavior.Restrict);
                //.OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Especie>().HasMany(e=>e.EcosistemasHabitados).WithOne().HasForeignKey(eC => eC.EspecieId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
