using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class majDevoirEtNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Grade",
                table: "StudentAssignment",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "StudentAssignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Assignment",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Assignment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "66d1633b-b01b-461a-a3f9-1ffd2bc61f31", "AQAAAAIAAYagAAAAEFJqIuiNBKizemG/GA4JzcGa85vcRwQDj47tXi+xlJMdgciT7wUwH2oTjEq2zhOevA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "StudentAssignment");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Assignment");

            migrationBuilder.AlterColumn<int>(
                name: "Grade",
                table: "StudentAssignment",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2653f2a6-20a5-4edd-84a7-c945ce404c1f", "AQAAAAIAAYagAAAAEPLFPE5U5SKVHxmpYTgQZ7NrF184NwNxJ5WLrORcISh9a8RBo16G0xX4kl+vpYp+Nw==" });
        }
    }
}
