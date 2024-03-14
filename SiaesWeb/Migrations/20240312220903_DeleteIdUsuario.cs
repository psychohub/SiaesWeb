using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiaesServer.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIdUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
