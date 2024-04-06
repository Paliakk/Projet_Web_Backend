using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class CourseInstructortable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseInstructor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseInstructor_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1b90265-108c-4883-93c5-178ba0cacc8f", "AQAAAAIAAYagAAAAEGl68gMBffpRBfQ42UoQr+uy57FSC0ZpMCpJyid5EE8TBfI3HwVR/l2qh+6Wh2uuvA==" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_CourseID",
                table: "CourseInstructor",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseInstructor_UserID",
                table: "CourseInstructor",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInstructor");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23447ed1-7837-46c3-a32b-0a7cda2dd278", "AQAAAAIAAYagAAAAEAWaHZ/FzeZ9lduCYViTnu1yNI44o+zkYpTT2E+M/ujuy0iE5e6iDzl6LfYblqgK5Q==" });
        }
    }
}
