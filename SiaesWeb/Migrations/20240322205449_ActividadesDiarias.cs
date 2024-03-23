using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiaesServer.Migrations
{
    /// <inheritdoc />
    public partial class ActividadesDiarias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IEMUsuariosInformes_IEMInformes_InformeCOD_INFORME",
                table: "IEMUsuariosInformes");

            migrationBuilder.DropIndex(
                name: "IX_IEMUsuariosInformes_InformeCOD_INFORME",
                table: "IEMUsuariosInformes");

            migrationBuilder.DropColumn(
                name: "InformeCOD_INFORME",
                table: "IEMUsuariosInformes");

            migrationBuilder.CreateTable(
                name: "TActividadesMacro",
                columns: table => new
                {
                    IdActividadMacro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionMacro = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TActividadesMacro", x => x.IdActividadMacro);
                });

            migrationBuilder.CreateTable(
                name: "TActividadesSustantivas",
                columns: table => new
                {
                    IdActividad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionActividad = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TActividadesSustantivas", x => x.IdActividad);
                });

            migrationBuilder.CreateTable(
                name: "TProcesos",
                columns: table => new
                {
                    IdProceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionProceso = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProcesos", x => x.IdProceso);
                });

            migrationBuilder.CreateTable(
                name: "TSubProcesos",
                columns: table => new
                {
                    IdSubProceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionSubProceso = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TSubProcesos", x => x.IdSubProceso);
                });

            migrationBuilder.CreateTable(
                name: "TUbicaciones",
                columns: table => new
                {
                    IdUbicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionUbicacion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUbicaciones", x => x.IdUbicacion);
                });

            migrationBuilder.CreateTable(
                name: "TDetallesProcesos",
                columns: table => new
                {
                    IdDetalleProceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProceso = table.Column<int>(type: "int", nullable: false),
                    IdSubProceso = table.Column<int>(type: "int", nullable: false),
                    IdActividad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDetallesProcesos", x => x.IdDetalleProceso);
                    table.ForeignKey(
                        name: "FK_TDetallesProcesos_TActividadesSustantivas_IdActividad",
                        column: x => x.IdActividad,
                        principalTable: "TActividadesSustantivas",
                        principalColumn: "IdActividad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TDetallesProcesos_TProcesos_IdProceso",
                        column: x => x.IdProceso,
                        principalTable: "TProcesos",
                        principalColumn: "IdProceso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TDetallesProcesos_TSubProcesos_IdSubProceso",
                        column: x => x.IdSubProceso,
                        principalTable: "TSubProcesos",
                        principalColumn: "IdSubProceso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TDetallesProcesosSubAreas",
                columns: table => new
                {
                    IdDetalleProcesoSubArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDetalleProceso = table.Column<int>(type: "int", nullable: false),
                    IdSubArea = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TDetallesProcesosSubAreas", x => x.IdDetalleProcesoSubArea);
                    table.ForeignKey(
                        name: "FK_TDetallesProcesosSubAreas_TDetallesProcesos_IdDetalleProceso",
                        column: x => x.IdDetalleProceso,
                        principalTable: "TDetallesProcesos",
                        principalColumn: "IdDetalleProceso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TDetallesProcesosSubAreas_T_SubArea_IdSubArea",
                        column: x => x.IdSubArea,
                        principalTable: "T_SubArea",
                        principalColumn: "IdSubArea",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TRegistrosDiarios",
                columns: table => new
                {
                    IdRegistro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    FechaActividad = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdDetalleProceso = table.Column<int>(type: "int", nullable: false),
                    IdActividadMacro = table.Column<int>(type: "int", nullable: false),
                    JustificacionRegAtrasado = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TiempoInvertido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdSubArea = table.Column<int>(type: "int", nullable: true),
                    IdUbicacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRegistrosDiarios", x => x.IdRegistro);
                    table.ForeignKey(
                        name: "FK_TRegistrosDiarios_TActividadesMacro_IdActividadMacro",
                        column: x => x.IdActividadMacro,
                        principalTable: "TActividadesMacro",
                        principalColumn: "IdActividadMacro",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRegistrosDiarios_TDetallesProcesos_IdDetalleProceso",
                        column: x => x.IdDetalleProceso,
                        principalTable: "TDetallesProcesos",
                        principalColumn: "IdDetalleProceso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRegistrosDiarios_TUbicaciones_IdUbicacion",
                        column: x => x.IdUbicacion,
                        principalTable: "TUbicaciones",
                        principalColumn: "IdUbicacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRegistrosDiarios_T_SubArea_IdSubArea",
                        column: x => x.IdSubArea,
                        principalTable: "T_SubArea",
                        principalColumn: "IdSubArea",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRegistrosDiarios_Usuario_IdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TDetallesProcesos_IdActividad",
                table: "TDetallesProcesos",
                column: "IdActividad");

            migrationBuilder.CreateIndex(
                name: "IX_TDetallesProcesos_IdProceso",
                table: "TDetallesProcesos",
                column: "IdProceso");

            migrationBuilder.CreateIndex(
                name: "IX_TDetallesProcesos_IdSubProceso",
                table: "TDetallesProcesos",
                column: "IdSubProceso");

            migrationBuilder.CreateIndex(
                name: "IX_TDetallesProcesosSubAreas_IdDetalleProceso",
                table: "TDetallesProcesosSubAreas",
                column: "IdDetalleProceso");

            migrationBuilder.CreateIndex(
                name: "IX_TDetallesProcesosSubAreas_IdSubArea",
                table: "TDetallesProcesosSubAreas",
                column: "IdSubArea");

            migrationBuilder.CreateIndex(
                name: "IX_TRegistrosDiarios_IdActividadMacro",
                table: "TRegistrosDiarios",
                column: "IdActividadMacro");

            migrationBuilder.CreateIndex(
                name: "IX_TRegistrosDiarios_IdDetalleProceso",
                table: "TRegistrosDiarios",
                column: "IdDetalleProceso");

            migrationBuilder.CreateIndex(
                name: "IX_TRegistrosDiarios_IdFuncionario",
                table: "TRegistrosDiarios",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "IX_TRegistrosDiarios_IdSubArea",
                table: "TRegistrosDiarios",
                column: "IdSubArea");

            migrationBuilder.CreateIndex(
                name: "IX_TRegistrosDiarios_IdUbicacion",
                table: "TRegistrosDiarios",
                column: "IdUbicacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TDetallesProcesosSubAreas");

            migrationBuilder.DropTable(
                name: "TRegistrosDiarios");

            migrationBuilder.DropTable(
                name: "TActividadesMacro");

            migrationBuilder.DropTable(
                name: "TDetallesProcesos");

            migrationBuilder.DropTable(
                name: "TUbicaciones");

            migrationBuilder.DropTable(
                name: "TActividadesSustantivas");

            migrationBuilder.DropTable(
                name: "TProcesos");

            migrationBuilder.DropTable(
                name: "TSubProcesos");

            migrationBuilder.AddColumn<string>(
                name: "InformeCOD_INFORME",
                table: "IEMUsuariosInformes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IEMUsuariosInformes_InformeCOD_INFORME",
                table: "IEMUsuariosInformes",
                column: "InformeCOD_INFORME");

            migrationBuilder.AddForeignKey(
                name: "FK_IEMUsuariosInformes_IEMInformes_InformeCOD_INFORME",
                table: "IEMUsuariosInformes",
                column: "InformeCOD_INFORME",
                principalTable: "IEMInformes",
                principalColumn: "COD_INFORME");
        }
    }
}
