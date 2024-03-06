using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentUsername = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    StudentsStudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursesCourseId, x.StudentsStudentId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_Students_StudentsStudentId",
                        column: x => x.StudentsStudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "AdminUsername" },
                values: new object[,]
                {
                    { 1, "admin1" },
                    { 2, "admin2" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseDescription", "CourseName" },
                values: new object[,]
                {
                    { 1, "Web Development is fun!", "Web Development" },
                    { 2, "Java Programming is fun! Fun! Fun! ", "Java Programming" },
                    { 3, "C# Programming is fun too!", "C# Programming" },
                    { 4, "Learn about data structures.", "Data Structures" },
                    { 5, "Study the fundamentals of algorithms.", "Algorithms" },
                    { 6, "Dive into computer networking principles.", "Computer Networks" },
                    { 7, "Explore how operating systems work.", "Operating Systems" },
                    { 8, "Understand database management systems.", "Database Systems" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "InstructorId", "InstructorUsername" },
                values: new object[,]
                {
                    { 1, "instructor1" },
                    { 2, "instructor2" },
                    { 3, "Dr. Jordan" },
                    { 4, "Prof. Morgan" },
                    { 5, "Dr. Casey" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "StudentUsername" },
                values: new object[,]
                {
                    { 1, "Igor" },
                    { 2, "Steven" },
                    { 3, "Damien" },
                    { 4, "AlexSmith" },
                    { 5, "JamieDoe" },
                    { 6, "ChrisJohnson" },
                    { 7, "PatTaylor" },
                    { 8, "SamBrown" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsStudentId",
                table: "CourseStudent",
                column: "StudentsStudentId");
            
            migrationBuilder.Sql("INSERT INTO CourseStudent (StudentsStudentId, CoursesCourseId) VALUES (1, 1);");
            migrationBuilder.Sql("INSERT INTO CourseStudent (StudentsStudentId, CoursesCourseId) VALUES (1, 2);");
            migrationBuilder.Sql("INSERT INTO CourseStudent (StudentsStudentId, CoursesCourseId) VALUES (2, 1);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
            migrationBuilder.Sql("DELETE FROM CourseStudent (StudentsStudentId, CoursesCourseId) VALUES (1, 1);");
            migrationBuilder.Sql("DELETE FROM CourseStudent (StudentsStudentId, CoursesCourseId) VALUES (1, 2);");
            migrationBuilder.Sql("DELETE FROM CourseStudent (StudentsStudentId, CoursesCourseId) VALUES (2, 1);");
        }
    }
}
