using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bdapis.Server.Migrations
{
    /// <inheritdoc />
    public partial class actclase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnuncioId",
                table: "Transmisiones",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnuncioId",
                table: "Transmisiones");
        }
    }
}
