using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class courseStudentupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseName",
                table: "CourseStudent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "CourseStudent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23447ed1-7837-46c3-a32b-0a7cda2dd278", "AQAAAAIAAYagAAAAEAWaHZ/FzeZ9lduCYViTnu1yNI44o+zkYpTT2E+M/ujuy0iE5e6iDzl6LfYblqgK5Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseName",
                table: "CourseStudent");

            migrationBuilder.DropColumn(
                name: "username",
                table: "CourseStudent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8ee51228-a0ad-44d6-9544-2d0d195c0bde", "AQAAAAIAAYagAAAAEPfeDDSltfLLGWvGAjgrKB6Mk7LF6e4q9pI5mA9vZhY+fMcpPruWwKeKBjxOXkwU8A==" });
        }
    }
}
