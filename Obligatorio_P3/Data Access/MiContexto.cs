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

        public DbSet<Especie> Especies { get; set; }

        public DbSet<EstadoConservacion> EstadosCo { get; set; }

        public DbSet<Pais> Paises { get; set; }

        public DbSet<UbiGeografica> UbisGeograficas { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

        public MiContexto(DbContextOptions options) : base(options) {

        }



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Amenaza>().HasKey(a => a.AmenazaId);
            modelBuilder.Entity<Audit>().HasKey(a => a.AuditId);
            modelBuilder.Entity<EcosistemaMarino>().HasKey(em => em.EcosistemaMarinoId);
            modelBuilder.Entity<Especie>().HasKey(e => e.EspecieId);
            modelBuilder.Entity<EstadoConservacion>().HasKey(ec => ec.EstadoConservacionId);
            modelBuilder.Entity<Pais>().HasKey(pais => pais.PaisId);
            modelBuilder.Entity<UbiGeografica>().HasKey(ubi=>ubi.UbiGeograficaId);
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioId);

            // relaciones
            modelBuilder.Entity<EcosistemaMarino>().HasMany(em => em.Amenazas).WithOne().HasForeignKey(a => a.EcosistemaMarinoId);
            modelBuilder.Entity<Pais>().HasMany(p => p.ecosistemaMarinos).WithOne().HasForeignKey(ec => ec.PaisId);

        }
    }
}
