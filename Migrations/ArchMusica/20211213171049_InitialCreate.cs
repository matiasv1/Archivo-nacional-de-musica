using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppV1.Migrations.ArchMusica
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peticiones",
                columns: table => new
                {
                    PeticionID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    Asunto = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Emisor = table.Column<string>(type: "text", nullable: true),
                    EmailEmisor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peticiones", x => x.PeticionID);
                });

            migrationBuilder.CreateTable(
                name: "HistorialBusquedas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Peticion = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    URL = table.Column<string>(type: "text", nullable: true),
                    PeticionID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialBusquedas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialBusquedas_Peticiones_PeticionID",
                        column: x => x.PeticionID,
                        principalTable: "Peticiones",
                        principalColumn: "PeticionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialBusquedas_PeticionID",
                table: "HistorialBusquedas",
                column: "PeticionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialBusquedas");

            migrationBuilder.DropTable(
                name: "Peticiones");
        }
    }
}
