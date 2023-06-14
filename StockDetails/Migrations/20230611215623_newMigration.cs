using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockDetails.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockDetails",
                columns: table => new
                {
                    StockID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    TodayHigh = table.Column<double>(type: "float", nullable: false),
                    TodayLow = table.Column<double>(type: "float", nullable: false),
                    YearHigh = table.Column<double>(type: "float", nullable: false),
                    YearLow = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDetails", x => x.StockID);
                });

            migrationBuilder.CreateTable(
                name: "DailyStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    High = table.Column<double>(type: "float", nullable: false),
                    Low = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StockID = table.Column<int>(type: "int", nullable: false),
                    StockDataStockID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyStocks_StockDetails_StockDataStockID",
                        column: x => x.StockDataStockID,
                        principalTable: "StockDetails",
                        principalColumn: "StockID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyStocks_StockDataStockID",
                table: "DailyStocks",
                column: "StockDataStockID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyStocks");

            migrationBuilder.DropTable(
                name: "StockDetails");
        }
    }
}
