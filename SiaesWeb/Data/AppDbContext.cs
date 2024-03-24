
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

        public DbSet<TProceso> T_Proceso { get; set; }
        public DbSet<TSubProceso> T_SubProceso { get; set; }
        public DbSet<TActividadSustantiva> T_ActividadSustantiva { get; set; }
        public DbSet<TDetalleProceso> T_DetalleProceso { get; set; }
        public DbSet<TDetalleProcesoSubArea> T_DetalleProcesoSubArea { get; set; }
        public DbSet<TActividadMacro> T_ActividadMacro { get; set; }
        public DbSet<TUbicacion> T_Ubicacion { get; set; }
        public DbSet<TRegistroDiario> T_RegistroDiario { get; set; }

        public DbSet<Bitacora> Bitacora { get; set; }




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

            modelBuilder.Entity<TDetalleProceso>()
            .HasOne(dp => dp.Proceso)
            .WithMany(p => p.DetallesProcesos)
            .HasForeignKey(dp => dp.IdProceso)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TDetalleProceso>()
                .HasOne(dp => dp.SubProceso)
                .WithMany(sp => sp.DetallesProcesos)
                .HasForeignKey(dp => dp.IdSubProceso)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TDetalleProceso>()
                .HasOne(dp => dp.ActividadSustantiva)
                .WithMany(a => a.DetallesProcesos)
                .HasForeignKey(dp => dp.IdActividad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TDetalleProcesoSubArea>()
                .HasOne(dpsa => dpsa.DetalleProceso)
                .WithMany(dp => dp.DetallesProcesosSubAreas)
                .HasForeignKey(dpsa => dpsa.IdDetalleProceso)
                .OnDelete(DeleteBehavior.Restrict);

           modelBuilder.Entity<TDetalleProcesoSubArea>()
                 .HasOne(dpsa => dpsa.SubArea)
                 .WithMany()
                 .HasForeignKey(dpsa => dpsa.IdSubArea)
                 .OnDelete(DeleteBehavior.Restrict);

           modelBuilder.Entity<TRegistroDiario>()
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(rd => rd.IdFuncionario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRegistroDiario>()
                .HasOne(rd => rd.DetalleProceso)
                .WithMany(dp => dp.RegistrosDiarios)
                .HasForeignKey(rd => rd.IdDetalleProceso)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRegistroDiario>()
                .HasOne(rd => rd.ActividadMacro)
                .WithMany(am => am.RegistrosDiarios)
                .HasForeignKey(rd => rd.IdActividadMacro)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRegistroDiario>()
                 .HasOne(rd => rd.SubArea)
                 .WithMany()
                 .HasForeignKey(rd => rd.IdSubArea)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TRegistroDiario>()
                .HasOne(rd => rd.Ubicacion)
                .WithMany(u => u.RegistrosDiarios)
                .HasForeignKey(rd => rd.IdUbicacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bitacora>()
           .ToTable("Bitacora");

            modelBuilder.Entity<TRegistroDiario>()
            .ToTable("T_RegistroDiario");

            modelBuilder.Entity<TUbicacion>()
           .ToTable("T_Ubicacion");
        }

    }
}
