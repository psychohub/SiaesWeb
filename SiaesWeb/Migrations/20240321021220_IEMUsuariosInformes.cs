using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiaesServer.Migrations
{
    /// <inheritdoc />
    public partial class IEMUsuariosInformes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
