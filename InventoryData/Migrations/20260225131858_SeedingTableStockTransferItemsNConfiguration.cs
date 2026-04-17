using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryData.Migrations
{
    /// <inheritdoc />
    public partial class SeedingTableStockTransferItemsNConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stockTransferItems_Products_ProductId",
                table: "stockTransferItems");

            migrationBuilder.DropForeignKey(
                name: "FK_stockTransferItems_StockTransfers_StockTransferId",
                table: "stockTransferItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stockTransferItems",
                table: "stockTransferItems");

            migrationBuilder.DropIndex(
                name: "IX_stockTransferItems_StockTransferId",
                table: "stockTransferItems");

            migrationBuilder.RenameTable(
                name: "stockTransferItems",
                newName: "StockTransferItems");

            migrationBuilder.RenameIndex(
                name: "IX_stockTransferItems_ProductId",
                table: "StockTransferItems",
                newName: "IX_StockTransferItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransferItems",
                table: "StockTransferItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "StockTransferItems",
                columns: new[] { "Id", "ProductId", "Quantity", "StockTransferId" },
                values: new object[,]
                {
                    { 1, 1, 5, 1 },
                    { 2, 3, 3, 2 },
                    { 3, 2, 20, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 25, 13, 18, 56, 100, DateTimeKind.Utc).AddTicks(555), "$2a$11$j2bE6z0T4uZjwnODjuF9COac1brtNZuofl.UIB9Qno6axddtwSKm6" });

            migrationBuilder.CreateIndex(
                name: "IX_StockTransferItems_StockTransferId_ProductId",
                table: "StockTransferItems",
                columns: new[] { "StockTransferId", "ProductId" },
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_StockTransferItem_Quantity_Positive",
                table: "StockTransferItems",
                sql: "[Quantity] > 0");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransferItems_Products_ProductId",
                table: "StockTransferItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransferItems_StockTransfers_StockTransferId",
                table: "StockTransferItems",
                column: "StockTransferId",
                principalTable: "StockTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransferItems_Products_ProductId",
                table: "StockTransferItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransferItems_StockTransfers_StockTransferId",
                table: "StockTransferItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransferItems",
                table: "StockTransferItems");

            migrationBuilder.DropIndex(
                name: "IX_StockTransferItems_StockTransferId_ProductId",
                table: "StockTransferItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_StockTransferItem_Quantity_Positive",
                table: "StockTransferItems");

            migrationBuilder.DeleteData(
                table: "StockTransferItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockTransferItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StockTransferItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "StockTransferItems",
                newName: "stockTransferItems");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransferItems_ProductId",
                table: "stockTransferItems",
                newName: "IX_stockTransferItems_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stockTransferItems",
                table: "stockTransferItems",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 17, 23, 38, 785, DateTimeKind.Utc).AddTicks(6087), "$2a$11$peZG3OW3iPDCoQXLiBh4letsCYEqsEojLWWc.YuWacm9c3KKRT/kW" });

            migrationBuilder.CreateIndex(
                name: "IX_stockTransferItems_StockTransferId",
                table: "stockTransferItems",
                column: "StockTransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_stockTransferItems_Products_ProductId",
                table: "stockTransferItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stockTransferItems_StockTransfers_StockTransferId",
                table: "stockTransferItems",
                column: "StockTransferId",
                principalTable: "StockTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
