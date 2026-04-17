using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryData.Migrations
{
    /// <inheritdoc />
    public partial class configureNSeededIntostockTransfersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransferItem_stockTransfers_StockTransferId",
                table: "StockTransferItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stockTransfers",
                table: "stockTransfers");

            migrationBuilder.RenameTable(
                name: "stockTransfers",
                newName: "StockTransfers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockTransfers",
                table: "StockTransfers",
                column: "Id");

            migrationBuilder.InsertData(
                table: "StockTransfers",
                columns: new[] { "Id", "FromWarehouseId", "ToWarehouseId", "TransferDate" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 3, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 1, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 17, 20, 17, 35, DateTimeKind.Utc).AddTicks(8496), "$2a$11$/hPOSE.8Bx90Ra0.RPPmceUVcQ9f0IB1HQ0xJ9k8TdexwsziStXje" });

            migrationBuilder.CreateIndex(
                name: "IX_StockTransfers_FromWarehouseId",
                table: "StockTransfers",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransfers_ToWarehouseId",
                table: "StockTransfers",
                column: "ToWarehouseId");

            migrationBuilder.AddCheckConstraint(
                name: "CK_StockTransfer_From_To_Different",
                table: "StockTransfers",
                sql: "[FromWarehouseId] <> [ToWarehouseId]");

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransferItem_StockTransfers_StockTransferId",
                table: "StockTransferItem",
                column: "StockTransferId",
                principalTable: "StockTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransfers_Warehouses_FromWarehouseId",
                table: "StockTransfers",
                column: "FromWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransfers_Warehouses_ToWarehouseId",
                table: "StockTransfers",
                column: "ToWarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockTransferItem_StockTransfers_StockTransferId",
                table: "StockTransferItem");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransfers_Warehouses_FromWarehouseId",
                table: "StockTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransfers_Warehouses_ToWarehouseId",
                table: "StockTransfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockTransfers",
                table: "StockTransfers");

            migrationBuilder.DropIndex(
                name: "IX_StockTransfers_FromWarehouseId",
                table: "StockTransfers");

            migrationBuilder.DropIndex(
                name: "IX_StockTransfers_ToWarehouseId",
                table: "StockTransfers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_StockTransfer_From_To_Different",
                table: "StockTransfers");

            migrationBuilder.DeleteData(
                table: "StockTransfers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "StockTransfers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "StockTransfers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "StockTransfers",
                newName: "stockTransfers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stockTransfers",
                table: "stockTransfers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 17, 10, 41, 17, DateTimeKind.Utc).AddTicks(5573), "$2a$11$c5KEo3aKEBDX/Te2SBJIVu/doYAiLMD..ge9ztDNWfOO72cZMaqFa" });

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransferItem_stockTransfers_StockTransferId",
                table: "StockTransferItem",
                column: "StockTransferId",
                principalTable: "stockTransfers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
