using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gerenciamento.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddNomeUsuarioToTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeUsuario",
                table: "Tarefas",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeUsuario",
                table: "Tarefas");
        }
    }
}
