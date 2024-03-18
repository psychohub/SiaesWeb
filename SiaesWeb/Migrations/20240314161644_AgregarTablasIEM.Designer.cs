﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SiaesServer.Data;

#nullable disable

namespace SiaesServer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240314161644_AgregarTablasIEM")]
    partial class AgregarTablasIEM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SiaesLibraryShared.Models.Establecimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CodEstablecimiento")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Establecimientos");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.IEMInforme", b =>
                {
                    b.Property<string>("COD_INFORME")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DSC_INFORME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Log_Activo")
                        .HasColumnType("int");

                    b.Property<int?>("Log_Activo_SACCE")
                        .HasColumnType("int");

                    b.Property<int?>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("COD_INFORME");

                    b.ToTable("IEMInformes");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.IEMUsuarioInforme", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("COD_INFORME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Cod_Establecimiento")
                        .HasColumnType("int");

                    b.Property<int?>("Log_Activo")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("IEMUsuariosInformes");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Model_Tanu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidosMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApellidosRecienNacido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CentroDiagnosticoReferencia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimientoRecienNacido")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPrimerTamizaje")
                        .HasColumnType("datetime2");

                    b.Property<string>("LateralidadDerechaGradoSordera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LateralidadDerechaTipoSordera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LateralidadIzquierdaGradoSordera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LateralidadIzquierdaTipoSordera")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreHospital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreRecienNacido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroIdentificacionMadre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroIdentificacionRecienNacido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PEAAV0_1")
                        .HasColumnType("bit");

                    b.Property<bool>("PEAAV0_2")
                        .HasColumnType("bit");

                    b.Property<bool>("PasaDerechoEOA")
                        .HasColumnType("bit");

                    b.Property<bool>("PasaIzquierdoEOA")
                        .HasColumnType("bit");

                    b.Property<string>("SexoRecienNacido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono1Madre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono2Madre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValoracionDiagnostica")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cuadro1_Tanu");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Perfiles");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Descripcion_Rol")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRol");

                    b.ToTable("T_Roles", (string)null);
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.SubArea", b =>
                {
                    b.Property<int>("IdSubArea")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSubArea"));

                    b.Property<string>("DescripcionSubArea")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("IdSubArea");

                    b.ToTable("T_SubArea", (string)null);
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CodEstablecimiento")
                        .HasColumnType("int");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCaducidad")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdSubArea")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioModificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioEstablecimiento", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    b.Property<int>("EstablecimientoId")
                        .HasColumnType("int")
                        .HasColumnName("EstablecimientoId");

                    b.HasKey("UsuarioId", "EstablecimientoId");

                    b.HasIndex("EstablecimientoId");

                    b.ToTable("UsuarioEstablecimientos");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioEstablecimientoPerfil", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("EstablecimientoId")
                        .HasColumnType("int");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerfilId1")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "EstablecimientoId", "PerfilId");

                    b.HasIndex("EstablecimientoId");

                    b.HasIndex("PerfilId");

                    b.HasIndex("PerfilId1");

                    b.ToTable("UsuarioEstablecimientoPerfil");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioPerfil", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("PerfilId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "PerfilId");

                    b.HasIndex("PerfilId");

                    b.ToTable("UsuarioPerfiles");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioRolSubArea", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("SubAreaId")
                        .HasColumnType("int");

                    b.Property<int?>("RolIdRol")
                        .HasColumnType("int");

                    b.Property<int?>("SubAreaIdSubArea")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id", "RolId", "SubAreaId");

                    b.HasIndex("RolId");

                    b.HasIndex("RolIdRol");

                    b.HasIndex("SubAreaId");

                    b.HasIndex("SubAreaIdSubArea");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioRolesSubAreas");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Establecimiento", b =>
                {
                    b.HasOne("SiaesLibraryShared.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioEstablecimiento", b =>
                {
                    b.HasOne("SiaesLibraryShared.Models.Establecimiento", "Establecimiento")
                        .WithMany("UsuarioEstablecimientos")
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiaesLibraryShared.Models.Usuario", "Usuario")
                        .WithMany("UsuarioEstablecimientos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establecimiento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioEstablecimientoPerfil", b =>
                {
                    b.HasOne("SiaesLibraryShared.Models.Establecimiento", "Establecimiento")
                        .WithMany("UsuarioEstablecimientoPerfiles")
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiaesLibraryShared.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiaesLibraryShared.Models.Perfil", null)
                        .WithMany("UsuarioEstablecimientoPerfiles")
                        .HasForeignKey("PerfilId1");

                    b.HasOne("SiaesLibraryShared.Models.Usuario", "Usuario")
                        .WithMany("UsuarioEstablecimientoPerfiles")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiaesLibraryShared.Models.UsuarioEstablecimiento", null)
                        .WithMany("UsuarioEstablecimientoPerfiles")
                        .HasForeignKey("UsuarioId", "EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establecimiento");

                    b.Navigation("Perfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioPerfil", b =>
                {
                    b.HasOne("SiaesLibraryShared.Models.Perfil", "Perfil")
                        .WithMany("UsuarioPerfiles")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiaesLibraryShared.Models.Usuario", "Usuario")
                        .WithMany("UsuarioPerfiles")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Perfil");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioRolSubArea", b =>
                {
                    b.HasOne("SiaesLibraryShared.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiaesLibraryShared.Models.Rol", null)
                        .WithMany("UsuarioRolesSubAreas")
                        .HasForeignKey("RolIdRol");

                    b.HasOne("SiaesLibraryShared.Models.SubArea", "SubArea")
                        .WithMany()
                        .HasForeignKey("SubAreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SiaesLibraryShared.Models.SubArea", null)
                        .WithMany("UsuarioRolesSubAreas")
                        .HasForeignKey("SubAreaIdSubArea");

                    b.HasOne("SiaesLibraryShared.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Rol");

                    b.Navigation("SubArea");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Establecimiento", b =>
                {
                    b.Navigation("UsuarioEstablecimientoPerfiles");

                    b.Navigation("UsuarioEstablecimientos");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Perfil", b =>
                {
                    b.Navigation("UsuarioEstablecimientoPerfiles");

                    b.Navigation("UsuarioPerfiles");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Rol", b =>
                {
                    b.Navigation("UsuarioRolesSubAreas");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.SubArea", b =>
                {
                    b.Navigation("UsuarioRolesSubAreas");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.Usuario", b =>
                {
                    b.Navigation("UsuarioEstablecimientoPerfiles");

                    b.Navigation("UsuarioEstablecimientos");

                    b.Navigation("UsuarioPerfiles");
                });

            modelBuilder.Entity("SiaesLibraryShared.Models.UsuarioEstablecimiento", b =>
                {
                    b.Navigation("UsuarioEstablecimientoPerfiles");
                });
#pragma warning restore 612, 618
        }
    }
}