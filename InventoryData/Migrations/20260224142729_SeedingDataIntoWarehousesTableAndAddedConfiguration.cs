using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryData.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataIntoWarehousesTableAndAddedConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Warehouses_WarehouseId",
                table: "Stock");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Warehouses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Warehouses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 14, 27, 28, 716, DateTimeKind.Utc).AddTicks(6001), "$2a$11$NCgt0mzAZCfXVfihV6oBOe5P/./gxHJCBcLcv1QRsT9.B0unjkdfG" });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Bangalore", "Central Warehouse" },
                    { 2, "Delhi", "North Distribution Center" },
                    { 3, "Mumbai", "West Storage Hub" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Name",
                table: "Warehouses",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Warehouses_WarehouseId",
                table: "Stock",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Warehouses_WarehouseId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_Name",
                table: "Warehouses");

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Warehouses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Warehouses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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
    }
}
