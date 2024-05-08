using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "656e99fb-9080-4e0f-8882-8ac94a126ed7", "AQAAAAIAAYagAAAAEGR+jItrxSPbUMq3E2E5EDS5jD5ZgVUWq8k2NFst/+AWrhJJLs4uZ9G4E9rLaK/YVg==", "adb9414d-882f-407f-83a5-e2d84de9967b", new DateTime(2024, 5, 8, 16, 4, 50, 783, DateTimeKind.Local).AddTicks(4383), "0cb00e2f-766a-402b-b2c4-9d163e9f5190" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d13bab52-4c22-463f-9945-6e78883ec7ef", "AQAAAAIAAYagAAAAEJjS+MoZff2QkmP/Hcw4ish2wyOcnumC+MTmXn8hwGD1w4dds9cQoknDB2S6MSFwLA==", null });
        }
    }
}
