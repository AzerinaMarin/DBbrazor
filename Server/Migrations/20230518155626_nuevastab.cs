using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bdapis.Server.Migrations
{
    /// <inheritdoc />
    public partial class nuevastab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingresos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnuncioId = table.Column<int>(type: "int", nullable: false),
                    AnunciosId = table.Column<int>(type: "int", nullable: true),
                    PatrocinadorId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Pagado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingresos_Anuncios_AnunciosId",
                        column: x => x.AnunciosId,
                        principalTable: "Anuncios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ingresos_Patrocinadores_PatrocinadorId",
                        column: x => x.PatrocinadorId,
                        principalTable: "Patrocinadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transmisiones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Encuentro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Torneo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnunciosId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmisiones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transmisiones_Anuncios_AnunciosId",
                        column: x => x.AnunciosId,
                        principalTable: "Anuncios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_AnunciosId",
                table: "Ingresos",
                column: "AnunciosId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingresos_PatrocinadorId",
                table: "Ingresos",
                column: "PatrocinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Transmisiones_AnunciosId",
                table: "Transmisiones",
                column: "AnunciosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingresos");

            migrationBuilder.DropTable(
                name: "Transmisiones");

            migrationBuilder.DropTable(
                name: "Anuncios");
        }
    }
}
