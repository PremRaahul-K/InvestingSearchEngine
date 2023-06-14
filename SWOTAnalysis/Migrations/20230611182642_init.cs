using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SWOTAnalysis.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oppurtunities",
                columns: table => new
                {
                    OppurtunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OppurtunityValue = table.Column<int>(type: "int", nullable: false),
                    OppurtunityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oppurtunities", x => x.OppurtunityId);
                });

            migrationBuilder.CreateTable(
                name: "Strengths",
                columns: table => new
                {
                    StrengthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrengthValue = table.Column<int>(type: "int", nullable: false),
                    StrengthDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strengths", x => x.StrengthId);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    ThreatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreatValue = table.Column<int>(type: "int", nullable: false),
                    ThreatDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.ThreatId);
                });

            migrationBuilder.CreateTable(
                name: "Weaknesses",
                columns: table => new
                {
                    WeaknessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeaknessValue = table.Column<int>(type: "int", nullable: false),
                    WeaknessDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weaknesses", x => x.WeaknessId);
                });

            migrationBuilder.CreateTable(
                name: "SWOT",
                columns: table => new
                {
                    SwotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    StrengthId = table.Column<int>(type: "int", nullable: false),
                    WeaknessId = table.Column<int>(type: "int", nullable: false),
                    ThreatId = table.Column<int>(type: "int", nullable: false),
                    OppurtunityId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SWOT", x => x.SwotId);
                    table.ForeignKey(
                        name: "FK_SWOT_Oppurtunities_OppurtunityId",
                        column: x => x.OppurtunityId,
                        principalTable: "Oppurtunities",
                        principalColumn: "OppurtunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SWOT_Strengths_StrengthId",
                        column: x => x.StrengthId,
                        principalTable: "Strengths",
                        principalColumn: "StrengthId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SWOT_Threats_ThreatId",
                        column: x => x.ThreatId,
                        principalTable: "Threats",
                        principalColumn: "ThreatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SWOT_Weaknesses_WeaknessId",
                        column: x => x.WeaknessId,
                        principalTable: "Weaknesses",
                        principalColumn: "WeaknessId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SWOT_OppurtunityId",
                table: "SWOT",
                column: "OppurtunityId");

            migrationBuilder.CreateIndex(
                name: "IX_SWOT_StrengthId",
                table: "SWOT",
                column: "StrengthId");

            migrationBuilder.CreateIndex(
                name: "IX_SWOT_ThreatId",
                table: "SWOT",
                column: "ThreatId");

            migrationBuilder.CreateIndex(
                name: "IX_SWOT_WeaknessId",
                table: "SWOT",
                column: "WeaknessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SWOT");

            migrationBuilder.DropTable(
                name: "Oppurtunities");

            migrationBuilder.DropTable(
                name: "Strengths");

            migrationBuilder.DropTable(
                name: "Threats");

            migrationBuilder.DropTable(
                name: "Weaknesses");
        }
    }
}
