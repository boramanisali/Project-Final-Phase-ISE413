using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BLL.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oblasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OblastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DeputyNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oblasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalParties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalParties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rayons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VoterNumber = table.Column<int>(type: "int", nullable: false),
                    OblastId = table.Column<int>(type: "int", nullable: false),
                    OblastsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rayons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rayons_Oblasts_OblastsId",
                        column: x => x.OblastsId,
                        principalTable: "Oblasts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    PoliticalPartiesId = table.Column<int>(type: "int", nullable: true),
                    OblastId = table.Column<int>(type: "int", nullable: false),
                    OblastsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participations_Oblasts_OblastsId",
                        column: x => x.OblastsId,
                        principalTable: "Oblasts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participations_PoliticalParties_PoliticalPartiesId",
                        column: x => x.PoliticalPartiesId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_OblastsId",
                table: "Participations",
                column: "OblastsId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_PoliticalPartiesId",
                table: "Participations",
                column: "PoliticalPartiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Rayons_OblastsId",
                table: "Rayons",
                column: "OblastsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "Rayons");

            migrationBuilder.DropTable(
                name: "PoliticalParties");

            migrationBuilder.DropTable(
                name: "Oblasts");
        }
    }
}
