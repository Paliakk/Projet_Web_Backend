using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class correctionRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "UserName" },
                values: new object[] { "e17fee8d-e420-4cfd-869c-89b103d85230", "ADMIN", "AQAAAAIAAYagAAAAEOXSYhWfDXKhSxcZz/kM8J2GF3axCwMWx4hZmh0/t1fyqSeWhNnwBmo/B4inkaj5cg==", "5e9b170d-3c49-46e8-ac0e-6048e3547158", new DateTime(2024, 5, 8, 18, 20, 59, 104, DateTimeKind.Local).AddTicks(455), "76d77a38-f961-4299-93ec-15655fd91399", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "UserName" },
                values: new object[] { "656e99fb-9080-4e0f-8882-8ac94a126ed7", "ADMIN@EPHEC.BE", "AQAAAAIAAYagAAAAEGR+jItrxSPbUMq3E2E5EDS5jD5ZgVUWq8k2NFst/+AWrhJJLs4uZ9G4E9rLaK/YVg==", "adb9414d-882f-407f-83a5-e2d84de9967b", new DateTime(2024, 5, 8, 16, 4, 50, 783, DateTimeKind.Local).AddTicks(4383), "0cb00e2f-766a-402b-b2c4-9d163e9f5190", "admin@ephec.be" });
        }
    }
}
