using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryData.Migrations
{
    /// <inheritdoc />
    public partial class AddedTablestockTransferItemsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransferItem_Products_ProductId",
                table: "StockTransferItem");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransferItem_StockTransfers_StockTransferId",
                table: "StockTransferItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransferItem",
                table: "StockTransferItem");

            migrationBuilder.RenameTable(
                name: "StockTransferItem",
                newName: "stockTransferItems");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransferItem_StockTransferId",
                table: "stockTransferItems",
                newName: "IX_stockTransferItems_StockTransferId");

            migrationBuilder.RenameIndex(
                name: "IX_StockTransferItem_ProductId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameTable(
                name: "stockTransferItems",
                newName: "StockTransferItem");

            migrationBuilder.RenameIndex(
                name: "IX_stockTransferItems_StockTransferId",
                table: "StockTransferItem",
                newName: "IX_StockTransferItem_StockTransferId");

            migrationBuilder.RenameIndex(
                name: "IX_stockTransferItems_ProductId",
                table: "StockTransferItem",
                newName: "IX_StockTransferItem_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransferItem",
                table: "StockTransferItem",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 17, 20, 17, 35, DateTimeKind.Utc).AddTicks(8496), "$2a$11$/hPOSE.8Bx90Ra0.RPPmceUVcQ9f0IB1HQ0xJ9k8TdexwsziStXje" });

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransferItem_Products_ProductId",
                table: "StockTransferItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransferItem_StockTransfers_StockTransferId",
                table: "StockTransferItem",
                column: "StockTransferId",
                principalTable: "StockTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
