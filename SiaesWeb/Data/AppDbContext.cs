
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

        public DbSet<Rol> Roles { get; set; }
        public DbSet<SubArea> SubAreas { get; set; }
        public DbSet<UsuarioRolSubArea> UsuarioRolesSubAreas { get; set; }

        public DbSet<IEMInforme> IEMInformes { get; set; }
        public DbSet<IEMUsuarioInforme> IEMUsuariosInformes { get; set; }

    


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

            modelBuilder.Entity<UsuarioEstablecimientoPerfil>()
                .HasKey(uep => new { uep.UsuarioId, uep.EstablecimientoId, uep.PerfilId });

            modelBuilder.Entity<UsuarioEstablecimientoPerfil>()
                .HasOne(uep => uep.Usuario)
                .WithMany(u => u.UsuarioEstablecimientoPerfiles)
                .HasForeignKey(uep => uep.UsuarioId);

            modelBuilder.Entity<UsuarioEstablecimientoPerfil>()
                .HasOne(uep => uep.Establecimiento)
                .WithMany(e => e.UsuarioEstablecimientoPerfiles)
                .HasForeignKey(uep => uep.EstablecimientoId);

            modelBuilder.Entity<UsuarioEstablecimientoPerfil>()
                .HasOne(uep => uep.Perfil)
                .WithMany()
                .HasForeignKey(uep => uep.PerfilId);

            modelBuilder.Entity<Rol>().ToTable("T_Roles");

            modelBuilder.Entity<SubArea>().ToTable("T_SubArea");

            modelBuilder.Entity<Rol>()
                .HasKey(r => r.IdRol);

            modelBuilder.Entity<Rol>()
                .Property(r => r.Descripcion_Rol)
                .HasMaxLength(50);

            modelBuilder.Entity<SubArea>()
                .HasKey(sa => sa.IdSubArea);

            modelBuilder.Entity<SubArea>()
                .Property(sa => sa.DescripcionSubArea)
                .HasMaxLength(150);

            modelBuilder.Entity<UsuarioRolSubArea>()
                .HasKey(urs => new { urs.Id, urs.RolId, urs.SubAreaId });

            modelBuilder.Entity<UsuarioRolSubArea>()
                .HasOne(urs => urs.Rol)
                .WithMany()
                .HasForeignKey(urs => urs.RolId);

            modelBuilder.Entity<UsuarioRolSubArea>()
                .HasOne(urs => urs.SubArea)
                .WithMany()
                .HasForeignKey(urs => urs.SubAreaId);

            modelBuilder.Entity<IEMUsuarioInforme>()
                .HasOne(ui => ui.Informe)
                .WithMany()
                .HasForeignKey(ui => ui.COD_INFORME);

        }

    }
}
