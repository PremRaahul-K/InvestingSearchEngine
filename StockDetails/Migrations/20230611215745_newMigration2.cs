using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockDetails.Migrations
{
    public partial class newMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyStocks_StockDetails_StockDataStockID",
                table: "DailyStocks");

            migrationBuilder.DropColumn(
                name: "StockID",
                table: "DailyStocks");

            migrationBuilder.AlterColumn<int>(
                name: "StockDataStockID",
                table: "DailyStocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyStocks_StockDetails_StockDataStockID",
                table: "DailyStocks",
                column: "StockDataStockID",
                principalTable: "StockDetails",
                principalColumn: "StockID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyStocks_StockDetails_StockDataStockID",
                table: "DailyStocks");

            migrationBuilder.AlterColumn<int>(
                name: "StockDataStockID",
                table: "DailyStocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StockID",
                table: "DailyStocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_DailyStocks_StockDetails_StockDataStockID",
                table: "DailyStocks",
                column: "StockDataStockID",
                principalTable: "StockDetails",
                principalColumn: "StockID");
        }
    }
}
