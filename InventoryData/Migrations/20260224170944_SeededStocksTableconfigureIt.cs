using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryData.Migrations
{
    /// <inheritdoc />
    public partial class SeededStocksTableconfigureIt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.CreateTable(
                name: "stockTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromWarehouseId = table.Column<int>(type: "int", nullable: false),
                    ToWarehouseId = table.Column<int>(type: "int", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockTransfers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTransferItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockTransferId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransferItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockTransferItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockTransferItem_stockTransfers_StockTransferId",
                        column: x => x.StockTransferId,
                        principalTable: "stockTransfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "ProductId", "Quantity", "WarehouseId" },
                values: new object[,]
                {
                    { 1, 1, 50, 1 },
                    { 2, 2, 120, 1 },
                    { 3, 3, 30, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 17, 9, 43, 779, DateTimeKind.Utc).AddTicks(7840), "$2a$11$lGEMLIm4GQglxqGk4EQI2OiOloF1SoynOZR/7sekE1MPDWj8WPEm." });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId_WarehouseId",
                table: "Stocks",
                columns: new[] { "ProductId", "WarehouseId" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Stock_Quantity_NonNegative",
                table: "Stocks",
                sql: "[Quantity] >= 0");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItem_ProductId",
                table: "StockTransferItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItem_StockTransferId",
                table: "StockTransferItem",
                column: "StockTransferId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTransferItem");

            migrationBuilder.DropTable(
                name: "stockTransfers");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId_WarehouseId",
                table: "Stocks");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Stock_Quantity_NonNegative",
                table: "Stocks");

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 14, 32, 15, 736, DateTimeKind.Utc).AddTicks(4242), "$2a$11$04RlEGAyLP5W6jDIj/37PuwyCG6dhHjUuDJspgxPMFW3esqL0Rb0y" });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");
        }
    }
}
