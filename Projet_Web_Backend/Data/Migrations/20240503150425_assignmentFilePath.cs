using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class assignmentFilePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "StudentAssignment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ed7254d1-f1a6-4972-914b-5386a2380bfa", "AQAAAAIAAYagAAAAEHzip8XqdoNv8VAzusCFYpe5i1zFgmxjpwHKbVEdcBD1WImrh67eZLhAZJ3W7Qnbaw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "StudentAssignment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "66d1633b-b01b-461a-a3f9-1ffd2bc61f31", "AQAAAAIAAYagAAAAEFJqIuiNBKizemG/GA4JzcGa85vcRwQDj47tXi+xlJMdgciT7wUwH2oTjEq2zhOevA==" });
        }
    }
}
