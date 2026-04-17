using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryData.Migrations
{
    /// <inheritdoc />
    public partial class AddedstockTransferTableToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 17, 10, 41, 17, DateTimeKind.Utc).AddTicks(5573), "$2a$11$c5KEo3aKEBDX/Te2SBJIVu/doYAiLMD..ge9ztDNWfOO72cZMaqFa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "PasswordHash" },
                values: new object[] { new DateTime(2026, 2, 24, 17, 9, 43, 779, DateTimeKind.Utc).AddTicks(7840), "$2a$11$lGEMLIm4GQglxqGk4EQI2OiOloF1SoynOZR/7sekE1MPDWj8WPEm." });
        }
    }
}
