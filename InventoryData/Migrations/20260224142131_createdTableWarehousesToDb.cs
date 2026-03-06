using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryData.Migrations
{
    /// <inheritdoc />
    public partial class createdTableWarehousesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Warehouse_WarehouseId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse");

            migrationBuilder.RenameTable(
                name: "Warehouse",
                newName: "Warehouses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 14, 21, 31, 482, DateTimeKind.Utc).AddTicks(9133), "$2a$11$SmHvQMIH/v7bF1Iq4ojzyu1X5Sew1kxx2YbH3MdKG64R0CO3U59dO" });

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Warehouses_WarehouseId",
                table: "Stock",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Warehouses_WarehouseId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warehouses",
                table: "Warehouses");

            migrationBuilder.RenameTable(
                name: "Warehouses",
                newName: "Warehouse");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warehouse",
                table: "Warehouse",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 14, 18, 14, 929, DateTimeKind.Utc).AddTicks(8994), "$2a$11$wjL3uI1sM7FKafk7AfRQ1ee2d8VQK3akXhMIAYWqsYrU5K0JFVujy" });

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Warehouse_WarehouseId",
                table: "Stock",
                column: "WarehouseId",
                principalTable: "Warehouse",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
