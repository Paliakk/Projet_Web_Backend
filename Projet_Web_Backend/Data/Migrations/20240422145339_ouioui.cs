using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ouioui : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAssignment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAssignment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAssignment_Assignment_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2653f2a6-20a5-4edd-84a7-c945ce404c1f", "AQAAAAIAAYagAAAAEPLFPE5U5SKVHxmpYTgQZ7NrF184NwNxJ5WLrORcISh9a8RBo16G0xX4kl+vpYp+Nw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_CourseId",
                table: "Assignment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_AssignmentId",
                table: "StudentAssignment",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAssignment_StudentId",
                table: "StudentAssignment",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAssignment");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1b90265-108c-4883-93c5-178ba0cacc8f", "AQAAAAIAAYagAAAAEGl68gMBffpRBfQ42UoQr+uy57FSC0ZpMCpJyid5EE8TBfI3HwVR/l2qh+6Wh2uuvA==" });
        }
    }
}
