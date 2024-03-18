using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiaesServer.Migrations
{
    /// <inheritdoc />
    public partial class AgregarTablasIEM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEstablecimientoPerfil_UsuarioEstablecimientos_UsuarioEstablecimientoUsuarioId_UsuarioEstablecimientoEstablecimientoId",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRolesSubAreas_Roles_RolId",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRolesSubAreas_SubAreas_SubAreaId",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRolesSubAreas",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioEstablecimientoPerfil",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioEstablecimientoPerfil_UsuarioEstablecimientoUsuarioId_UsuarioEstablecimientoEstablecimientoId",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioEstablecimientoPerfil_UsuarioId",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubAreas",
                table: "SubAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UsuarioEstablecimientoEstablecimientoId",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.RenameTable(
                name: "SubAreas",
                newName: "T_SubArea");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "T_Roles");

            migrationBuilder.RenameColumn(
                name: "UsuarioEstablecimientoUsuarioId",
                table: "UsuarioEstablecimientoPerfil",
                newName: "PerfilId1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsuarioRolesSubAreas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "RolIdRol",
                table: "UsuarioRolesSubAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubAreaIdSubArea",
                table: "UsuarioRolesSubAreas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsuarioEstablecimientoPerfil",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionSubArea",
                table: "T_SubArea",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion_Rol",
                table: "T_Roles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRolesSubAreas",
                table: "UsuarioRolesSubAreas",
                columns: new[] { "Id", "RolId", "SubAreaId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioEstablecimientoPerfil",
                table: "UsuarioEstablecimientoPerfil",
                columns: new[] { "UsuarioId", "EstablecimientoId", "PerfilId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_SubArea",
                table: "T_SubArea",
                column: "IdSubArea");

            migrationBuilder.AddPrimaryKey(
                name: "PK_T_Roles",
                table: "T_Roles",
                column: "IdRol");

            migrationBuilder.CreateTable(
                name: "IEMInformes",
                columns: table => new
                {
                    COD_INFORME = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DSC_INFORME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Log_Activo = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true),
                    Log_Activo_SACCE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IEMInformes", x => x.COD_INFORME);
                });

            migrationBuilder.CreateTable(
                name: "IEMUsuariosInformes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COD_INFORME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cod_Establecimiento = table.Column<int>(type: "int", nullable: true),
                    Log_Activo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IEMUsuariosInformes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRolesSubAreas_RolIdRol",
                table: "UsuarioRolesSubAreas",
                column: "RolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRolesSubAreas_SubAreaIdSubArea",
                table: "UsuarioRolesSubAreas",
                column: "SubAreaIdSubArea");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstablecimientoPerfil_PerfilId1",
                table: "UsuarioEstablecimientoPerfil",
                column: "PerfilId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEstablecimientoPerfil_Perfiles_PerfilId1",
                table: "UsuarioEstablecimientoPerfil",
                column: "PerfilId1",
                principalTable: "Perfiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEstablecimientoPerfil_UsuarioEstablecimientos_UsuarioId_EstablecimientoId",
                table: "UsuarioEstablecimientoPerfil",
                columns: new[] { "UsuarioId", "EstablecimientoId" },
                principalTable: "UsuarioEstablecimientos",
                principalColumns: new[] { "UsuarioId", "EstablecimientoId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_Roles_RolId",
                table: "UsuarioRolesSubAreas",
                column: "RolId",
                principalTable: "T_Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_Roles_RolIdRol",
                table: "UsuarioRolesSubAreas",
                column: "RolIdRol",
                principalTable: "T_Roles",
                principalColumn: "IdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_SubArea_SubAreaId",
                table: "UsuarioRolesSubAreas",
                column: "SubAreaId",
                principalTable: "T_SubArea",
                principalColumn: "IdSubArea",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_SubArea_SubAreaIdSubArea",
                table: "UsuarioRolesSubAreas",
                column: "SubAreaIdSubArea",
                principalTable: "T_SubArea",
                principalColumn: "IdSubArea");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEstablecimientoPerfil_Perfiles_PerfilId1",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEstablecimientoPerfil_UsuarioEstablecimientos_UsuarioId_EstablecimientoId",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_Roles_RolId",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_Roles_RolIdRol",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_SubArea_SubAreaId",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioRolesSubAreas_T_SubArea_SubAreaIdSubArea",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropTable(
                name: "IEMInformes");

            migrationBuilder.DropTable(
                name: "IEMUsuariosInformes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioRolesSubAreas",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioRolesSubAreas_RolIdRol",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioRolesSubAreas_SubAreaIdSubArea",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioEstablecimientoPerfil",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioEstablecimientoPerfil_PerfilId1",
                table: "UsuarioEstablecimientoPerfil");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_SubArea",
                table: "T_SubArea");

            migrationBuilder.DropPrimaryKey(
                name: "PK_T_Roles",
                table: "T_Roles");

            migrationBuilder.DropColumn(
                name: "RolIdRol",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.DropColumn(
                name: "SubAreaIdSubArea",
                table: "UsuarioRolesSubAreas");

            migrationBuilder.RenameTable(
                name: "T_SubArea",
                newName: "SubAreas");

            migrationBuilder.RenameTable(
                name: "T_Roles",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "PerfilId1",
                table: "UsuarioEstablecimientoPerfil",
                newName: "UsuarioEstablecimientoUsuarioId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsuarioRolesSubAreas",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UsuarioEstablecimientoPerfil",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioEstablecimientoEstablecimientoId",
                table: "UsuarioEstablecimientoPerfil",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionSubArea",
                table: "SubAreas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion_Rol",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioRolesSubAreas",
                table: "UsuarioRolesSubAreas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioEstablecimientoPerfil",
                table: "UsuarioEstablecimientoPerfil",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubAreas",
                table: "SubAreas",
                column: "IdSubArea");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstablecimientoPerfil_UsuarioEstablecimientoUsuarioId_UsuarioEstablecimientoEstablecimientoId",
                table: "UsuarioEstablecimientoPerfil",
                columns: new[] { "UsuarioEstablecimientoUsuarioId", "UsuarioEstablecimientoEstablecimientoId" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEstablecimientoPerfil_UsuarioId",
                table: "UsuarioEstablecimientoPerfil",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEstablecimientoPerfil_UsuarioEstablecimientos_UsuarioEstablecimientoUsuarioId_UsuarioEstablecimientoEstablecimientoId",
                table: "UsuarioEstablecimientoPerfil",
                columns: new[] { "UsuarioEstablecimientoUsuarioId", "UsuarioEstablecimientoEstablecimientoId" },
                principalTable: "UsuarioEstablecimientos",
                principalColumns: new[] { "UsuarioId", "EstablecimientoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRolesSubAreas_Roles_RolId",
                table: "UsuarioRolesSubAreas",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "IdRol",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioRolesSubAreas_SubAreas_SubAreaId",
                table: "UsuarioRolesSubAreas",
                column: "SubAreaId",
                principalTable: "SubAreas",
                principalColumn: "IdSubArea",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
