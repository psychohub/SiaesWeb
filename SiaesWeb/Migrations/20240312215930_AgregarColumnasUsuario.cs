using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiaesServer.Migrations
{
    /// <inheritdoc />
    public partial class AgregarColumnasUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRol",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSubArea",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "CodEstablecimiento",
                table: "Establecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Establecimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "SubAreas",
                columns: table => new
                {
                    IdSubArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionSubArea = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubAreas", x => x.IdSubArea);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioEstablecimientoPerfil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstablecimientoId = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEstablecimientoEstablecimientoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioEstablecimientoUsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEstablecimientoPerfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioEstablecimientoPerfil_Establecimientos_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEstablecimientoPerfil_Perfiles_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEstablecimientoPerfil_UsuarioEstablecimientos_UsuarioEstablecimientoUsuarioId_UsuarioEstablecimientoEstablecimientoId",
                        columns: x => new { x.UsuarioEstablecimientoUsuarioId, x.UsuarioEstablecimientoEstablecimientoId },
                        principalTable: "UsuarioEstablecimientos",
                        principalColumns: new[] { "UsuarioId", "EstablecimientoId" });
                    table.ForeignKey(
                        name: "FK_UsuarioEstablecimientoPerfil_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRolesSubAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    SubAreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRolesSubAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRolesSubAreas_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRolesSubAreas_SubAreas_SubAreaId",
                        column: x => x.SubAreaId,
                        principalTable: "SubAreas",
                        principalColumn: "IdSubArea",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRolesSubAreas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establecimientos_UsuarioId",
                table: "Establecimientos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstablecimientoPerfil_EstablecimientoId",
                table: "UsuarioEstablecimientoPerfil",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstablecimientoPerfil_PerfilId",
                table: "UsuarioEstablecimientoPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstablecimientoPerfil_UsuarioEstablecimientoUsuarioId_UsuarioEstablecimientoEstablecimientoId",
                table: "UsuarioEstablecimientoPerfil",
                columns: new[] { "UsuarioEstablecimientoUsuarioId", "UsuarioEstablecimientoEstablecimientoId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstablecimientoPerfil_UsuarioId",
                table: "UsuarioEstablecimientoPerfil",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRolesSubAreas_RolId",
                table: "UsuarioRolesSubAreas",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRolesSubAreas_SubAreaId",
                table: "UsuarioRolesSubAreas",
                column: "SubAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRolesSubAreas_UsuarioId",
                table: "UsuarioRolesSubAreas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Establecimientos_Usuario_UsuarioId",
                table: "Establecimientos",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Establecimientos_Usuario_UsuarioId",
                table: "Establecimientos");

            migrationBuilder.DropTable(
                name: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropTable(
                name: "UsuarioRolesSubAreas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SubAreas");

            migrationBuilder.DropIndex(
                name: "IX_Establecimientos_UsuarioId",
                table: "Establecimientos");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "IdSubArea",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Establecimientos");

            migrationBuilder.AlterColumn<string>(
                name: "CodEstablecimiento",
                table: "Establecimientos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
