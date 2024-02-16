
using Microsoft.EntityFrameworkCore;
using SiaesLibraryShared.Models;
using System.Collections.Generic;

namespace SiaesServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Agregar los modelos
        public DbSet<Model_Tanu> Cuadro1_Tanu { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!;
        public DbSet<Establecimiento> Establecimientos { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<UsuarioEstablecimiento> UsuarioEstablecimientos { get; set; }
        public DbSet<UsuarioPerfil> UsuarioPerfiles { get; set; }
        public DbSet<UsuarioEstablecimientoPerfil> UsuarioEstablecimientoPerfil { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioEstablecimiento>()
                .HasKey(ue => new { ue.UsuarioId, ue.EstablecimientoId });

            modelBuilder.Entity<UsuarioEstablecimiento>()
                .HasOne(ue => ue.Usuario)
                .WithMany(u => u.UsuarioEstablecimientos)
                .HasForeignKey(ue => ue.UsuarioId);

            modelBuilder.Entity<UsuarioEstablecimiento>()
                .HasOne(ue => ue.Establecimiento)
                .WithMany(e => e.UsuarioEstablecimientos)
                .HasForeignKey(ue => ue.EstablecimientoId);

            modelBuilder.Entity<UsuarioEstablecimiento>()
                 .Property(ue => ue.UsuarioId)
                .HasColumnName("UsuarioId"); 

            modelBuilder.Entity<UsuarioEstablecimiento>()
                .Property(ue => ue.EstablecimientoId)
                .HasColumnName("EstablecimientoId");

            modelBuilder.Entity<UsuarioPerfil>()
                .HasKey(up => new { up.UsuarioId, up.PerfilId });

            modelBuilder.Entity<UsuarioPerfil>()
                .HasOne(up => up.Usuario)
                .WithMany(u => u.UsuarioPerfiles)
                .HasForeignKey(up => up.UsuarioId);

            modelBuilder.Entity<UsuarioPerfil>()
                .HasOne(up => up.Perfil)
                .WithMany(p => p.UsuarioPerfiles)
                .HasForeignKey(up => up.PerfilId);

       

        }

    }
}
