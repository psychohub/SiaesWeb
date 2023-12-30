using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiaesServer.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicialModeloRegistrarUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuadro1_Tanu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreHospital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentificacionMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidosMadre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono1Madre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono2Madre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroIdentificacionRecienNacido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreRecienNacido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApellidosRecienNacido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimientoRecienNacido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SexoRecienNacido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPrimerTamizaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasaDerechoEOA = table.Column<bool>(type: "bit", nullable: false),
                    PasaIzquierdoEOA = table.Column<bool>(type: "bit", nullable: false),
                    CentroDiagnosticoReferencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValoracionDiagnostica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PEAAV0_1 = table.Column<bool>(type: "bit", nullable: false),
                    PEAAV0_2 = table.Column<bool>(type: "bit", nullable: false),
                    LateralidadDerechaTipoSordera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LateralidadDerechaGradoSordera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LateralidadIzquierdaTipoSordera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LateralidadIzquierdaGradoSordera = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuadro1_Tanu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrarUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodEstablecimiento = table.Column<int>(type: "int", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioModificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrarUsuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cuadro1_Tanu");

            migrationBuilder.DropTable(
                name: "RegistrarUsuario");
        }
    }
}
