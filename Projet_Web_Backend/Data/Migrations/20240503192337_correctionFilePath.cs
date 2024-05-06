using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class correctionFilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "StudentAssignment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d13bab52-4c22-463f-9945-6e78883ec7ef", "AQAAAAIAAYagAAAAEJjS+MoZff2QkmP/Hcw4ish2wyOcnumC+MTmXn8hwGD1w4dds9cQoknDB2S6MSFwLA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "StudentAssignment",
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed7254d1-f1a6-4972-914b-5386a2380bfa", "AQAAAAIAAYagAAAAEHzip8XqdoNv8VAzusCFYpe5i1zFgmxjpwHKbVEdcBD1WImrh67eZLhAZJ3W7Qnbaw==" });
        }
    }
}
