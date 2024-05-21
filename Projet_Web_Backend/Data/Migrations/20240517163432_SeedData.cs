using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Seed Students And Instructors
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "55455058-9515-47fc-93ae-0d53ee557a8b", "john.doe@ephec.be", false, false, null, "JOHN.DOE@EPHEC.BE", "JOHNDOE", "AQAAAAIAAYagAAAAECUuOmYTeFI0v8bDVsqQ022crcPnz9QmtvKxrHMPEIdkeJNOqBtPRodydbUoPYKNyw==", null, false, null, null, "cbbff709-0b34-4c5f-b66f-4a83b13c5f47", false, "johndoe" },
                    { 3, 0, "80387357-6673-4660-a8de-09e88b0c1f71", "jane.doe@ephec.be", false, false, null, "JANE.DOE@EPHEC.BE", "JANEDOE", "AQAAAAIAAYagAAAAEMuzpy4L1ik5lvPkp9F7j1YJ1HdJyaX9DobIw5ErUULB2iDKDK7cfmLGSK2V1jIoQg==", null, false, null, null, "e075ea42-2efb-4f0d-ab6e-70527c66638c", false, "janedoe" },
                    { 4, 0, "99fa0ce8-1e88-44a6-804c-1586c6242051", "robert.smith@ephec.be", false, false, null, "ROBERT.SMITH@EPHEC.BE", "ROBERTSMITH", "AQAAAAIAAYagAAAAEBmXzfpL6d0qCvvm3R4vvnfYu5ODpy9juDBBcONefJKKIde83NaTwHU9XaTDvYdxdA==", null, false, null, null, "fb95450a-7259-4d3d-baf7-f3632aa8cab3", false, "robertsmith" },
                    { 5, 0, "296f3f7e-deab-4629-a0d1-1e3171b13995", "linda.johnson@ephec.be", false, false, null, "LINDA.JOHNSON@EPHEC.BE", "LINDAJOHNSON", "AQAAAAIAAYagAAAAEM/48KBDdqESpHdgbuNPsINufFcciwpDraw5BHMNwpwg07D4m7JR0rBioLwwsLWrjQ==", null, false, null, null, "1c389f62-f9cf-41c8-9ce5-916a39600db2", false, "lindajohnson" },
                    { 6, 0, "160c3256-94ab-4870-876a-d0626d582b11", "michael.brown@ephec.be", false, false, null, "MICHAEL.BROWN@EPHEC.BE", "MICHAELBROWN", "AQAAAAIAAYagAAAAED4z7m+KjpgwlxL7Xo61ZjuiLIRVBF+h+j/Nt5PaixgJH9EbAp2vp5heAJZT1URBCg==", null, false, null, null, "c63b80eb-e917-4b2f-aa4f-3e75d3795df6", false, "michaelbrown" },
                    { 7, 0, "ba8df7f3-556e-4121-868d-5bd8ae23b4c1", "alice.williams@ephec.be", false, false, null, "ALICE.WILLIAMS@EPHEC.BE", "ALICEWILLIAMS", "AQAAAAIAAYagAAAAEPEQ55fScO11CNWhJYxwzXds08tZoRodvXaQgaw9oyhxRVuJ7rgCAZlzru15hmA6PQ==", null, false, null, null, "ebc3c858-6e6e-4e7c-b93e-26349d5c851a", false, "alicewilliams" },
                    { 8, 0, "13591acf-b463-48ec-8978-cbb92616a51a", "james.jones@ephec.be", false, false, null, "JAMES.JONES@EPHEC.BE", "JAMESJONES", "AQAAAAIAAYagAAAAECaj6YGkdIhqfmKYns6HVHIykHAtRJZyll24I/eIX6dIqf11rFBhkcBwNMTTOrLvuQ==", null, false, null, null, "0ef31cf3-d857-4549-8806-ee9c62bffde8", false, "jamesjones" },
                    { 9, 0, "1c864518-f97d-4c23-ae79-039e6f881e54", "emily.davis@ephec.be", false, false, null, "EMILY.DAVIS@EPHEC.BE", "EMILYDAVIS", "AQAAAAIAAYagAAAAEBpwWJUECkY9i6+AQNn8Cc6KeeUebmHnwzqETjcqd534uPuZbSHYEjsk+Cl2jGeXdg==", null, false, null, null, "f1065f30-c1f7-48cc-88a1-badbc9c3ae3f", false, "emilydavis" },
                    { 10, 0, "bc678ffe-fba8-4311-9e0f-0ee0c7c37ddf", "william.wilson@ephec.be", false, false, null, "WILLIAM.WILSON@EPHEC.BE", "WILLIAMWILSON", "AQAAAAIAAYagAAAAEFJzBzEpyzO6Y0pu4YT03mntPkRrZobIDCVmlKvea6Q3SFsbxrvg9RRP0GuI135sPQ==", null, false, null, null, "5351cc0e-c9d2-472f-bf50-a99a5fbdc417", false, "williamwilson" },
                    { 11, 0, "3b993814-1e82-4bab-9ae3-545db37fcb28", "sophia.miller@ephec.be", false, false, null, "SOPHIA.MILLER@EPHEC.BE", "SOPHIAMILLER", "AQAAAAIAAYagAAAAEHI0iCPf6JaLZEDk52zmNc42NGW5n/q4si4PsNn6aSetHlyPKSh2pqVQAInKmPxrlA==", null, false, null, null, "b1842ff0-8083-4523-a9f2-3064a3925de1", false, "sophiamiller" }
                });
            // Seed Roles
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 }
                });
            // Seed courses
            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name", "Description" },
                values: new object[,]
                {
                { 1, "Web Development", "Web Development is fun!" },
                { 2, "Java Programming", "Java Programming is fun! Fun! Fun!" },
                { 3, "C# Programming", "C# Programming is fun too!" },
                { 4, "Data Structures", "Learn about data structures." },
                { 5, "Algorithms", "Study the fundamentals of algorithms." },
                { 6, "Computer Networks", "Dive into computer networking principles." },
                { 7, "Operating Systems", "Explore how operating systems work." },
                { 8, "Database Systems", "Understand database management systems." }
                });
            // Seed assignments
            migrationBuilder.InsertData(
                table: "Assignment",
                columns: new[] { "Id", "CourseId", "Title", "Description", "Deadline", "CreatedAt", "Status" },
                values: new object[,]
                {
                { 1, 1, "HTML Basics", "Introduction to HTML", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 2, 1, "CSS Styling", "Learn to style with CSS", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 3, 1, "JavaScript Fundamentals", "Basic JavaScript concepts", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 4, 2, "Java Syntax", "Learn the syntax of Java", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 5, 2, "OOP in Java", "Object-Oriented Programming concepts", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 6, 2, "Java Collections", "Explore Java Collections Framework", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 7, 3, "C# Basics", "Introduction to C#", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 8, 3, "LINQ", "Language Integrated Query in C#", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 9, 3, "Async Programming", "Asynchronous programming in C#", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 10, 4, "Arrays and Lists", "Basic data structures", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 11, 4, "Trees and Graphs", "Advanced data structures", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 12, 4, "Hash Tables", "Understanding hash tables", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 13, 5, "Sorting Algorithms", "Basic sorting techniques", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 14, 5, "Search Algorithms", "Introduction to searching", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 15, 5, "Dynamic Programming", "Advanced algorithmic techniques", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 16, 6, "Network Basics", "Introduction to networking", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 17, 6, "TCP/IP Protocol", "Understanding TCP/IP", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 18, 6, "Network Security", "Basics of network security", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 19, 7, "OS Fundamentals", "Basic concepts of OS", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 20, 7, "Process Management", "Understanding processes", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 21, 7, "Memory Management", "How OS manages memory", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 22, 8, "SQL Basics", "Introduction to SQL", DateTime.Now.AddDays(-7), DateTime.Now, "Completed" },
                { 23, 8, "Normalization", "Database normalization techniques", DateTime.Now.AddDays(14), DateTime.Now, "Submitted" },
                { 24, 8, "Indexing", "Optimizing database performance", DateTime.Now.AddDays(21), DateTime.Now, "Late" },
                { 25, 1, "Build a Personal Website", "Create a personal website using HTML, CSS, and JavaScript", DateTime.Now.AddDays(30), DateTime.Now, "Active" },
                { 26, 2, "Create a Java Project", "Develop a Java project using OOP principles", DateTime.Now.AddDays(30), DateTime.Now, "Active" },
                { 27, 3, "C# Console Application", "Build a console application using C#", DateTime.Now.AddDays(30), DateTime.Now, "Active" },
                { 28, 4, "Implement a Data Structure", "Implement and test various data structures", DateTime.Now.AddDays(30), DateTime.Now, "Active" },
                { 29, 5, "Algorithm Optimization", "Optimize a given algorithm for better performance", DateTime.Now.AddDays(30), DateTime.Now, "Active" },
                { 30, 6, "Network Configuration", "Configure and test a computer network", DateTime.Now.AddDays(30), DateTime.Now, "Active" },
                { 31, 7, "Operating System Simulation", "Simulate an OS feature", DateTime.Now.AddDays(30), DateTime.Now, "Active" },
                { 32, 8, "Database Design", "Design and implement a database system", DateTime.Now.AddDays(30), DateTime.Now, "Active" }
                });
            // Seed CourseInstructors
            migrationBuilder.InsertData(
                table: "CourseInstructor",
                columns: new[] { "Id", "UserID", "username", "CourseID", "CourseName" },
                values: new object[,]
                {
                { 1, 2, "johndoe", 1, "Web Development" },
                { 2, 2, "johndoe", 2, "Java Programming" },
                { 3, 2, "johndoe", 3, "C# Programming" },
                { 4, 3, "janedoe", 4, "Data Structures" },
                { 5, 3, "janedoe", 5, "Algorithms" },
                { 6, 4, "robertsmith", 6, "Computer Networks" },
                { 7, 5, "lindajohnson", 7, "Operating Systems" },
                { 8, 6, "michaelbrown", 8, "Database Systems" }
                });
            // Seed CourseStudents
            migrationBuilder.InsertData(
                table: "CourseStudent",
                columns: new[] { "Id", "UserID", "username", "CourseID", "CourseName" },
                values: new object[,]
                {
                { 1, 7, "alicewilliams", 1, "Web Development" },
                { 2, 7, "alicewilliams", 2, "Java Programming" },
                { 3, 7, "alicewilliams", 3, "C# Programming" },
                { 4, 7, "alicewilliams", 4, "Data Structures" },
                { 5, 7, "alicewilliams", 5, "Algorithms" },
                { 6, 7, "alicewilliams", 6, "Computer Networks" },
                { 7, 7, "alicewilliams", 7, "Operating Systems" },
                { 8, 7, "alicewilliams", 8, "Database Systems" },
                { 9, 8, "jamesjones", 1, "Web Development" },
                { 10, 8, "jamesjones", 2, "Java Programming" },
                { 11, 8, "jamesjones", 3, "C# Programming" },
                { 12, 8, "jamesjones", 4, "Data Structures" },
                { 13, 8, "jamesjones", 5, "Algorithms" },
                { 14, 8, "jamesjones", 6, "Computer Networks" },
                { 15, 9, "emilydavis", 1, "Web Development" },
                { 16, 9, "emilydavis", 2, "Java Programming" },
                { 17, 9, "emilydavis", 3, "C# Programming" },
                { 18, 9, "emilydavis", 4, "Data Structures" },
                { 19, 9, "emilydavis", 5, "Algorithms" },
                { 20, 9, "emilydavis", 6, "Computer Networks" },
                { 21, 10, "williamwilson", 1, "Web Development" },
                { 22, 10, "williamwilson", 2, "Java Programming" },
                { 23, 10, "williamwilson", 3, "C# Programming" },
                { 24, 10, "williamwilson", 4, "Data Structures" },
                { 25, 10, "williamwilson", 5, "Algorithms" },
                { 26, 11, "sophiamiller", 1, "Web Development" },
                { 27, 11, "sophiamiller", 2, "Java Programming" },
                { 28, 11, "sophiamiller", 3, "C# Programming" },
                { 29, 11, "sophiamiller", 4, "Data Structures" },
                { 30, 11, "sophiamiller", 5, "Algorithms" },
                { 31, 11, "sophiamiller", 6, "Computer Networks" }
                });
            // Seed StudentAssignments
            migrationBuilder.InsertData(
                table: "StudentAssignment",
                columns: new[] { "Id", "StudentId", "AssignmentId", "Grade", "Status", "FilePath" },
                values: new object[,]
                {
                    { 1, 7, 1, 18.0m, "Completed", "path/to/completed/7_1.pdf" },
                    { 2, 7, 2, null, "Submitted", "path/to/submitted/7_2.pdf" },
                    { 3, 7, 3, null, "Late", null },
                    { 4, 7, 4, 17.0m, "Completed", "path/to/completed/7_4.pdf" },
                    { 5, 7, 5, null, "Submitted", "path/to/submitted/7_5.pdf" },
                    { 6, 7, 6, null, "Late", null },
                    { 7, 7, 7, 16.0m, "Completed", "path/to/completed/7_7.pdf" },
                    { 8, 7, 8, null, "Submitted", "path/to/submitted/7_8.pdf" },
                    { 9, 7, 9, null, "Late", null },
                    { 10, 7, 10, 15.0m, "Completed", "path/to/completed/7_10.pdf" },
                    { 11, 7, 11, null, "Submitted", "path/to/submitted/7_11.pdf" },
                    { 12, 7, 12, null, "Late", null },
                    { 13, 7, 13, 14.0m, "Completed", "path/to/completed/7_13.pdf" },
                    { 14, 7, 14, null, "Submitted", "path/to/submitted/7_14.pdf" },
                    { 15, 7, 15, null, "Late", null },
                    { 16, 7, 16, 13.0m, "Completed", "path/to/completed/7_16.pdf" },
                    { 17, 7, 17, null, "Submitted", "path/to/submitted/7_17.pdf" },
                    { 18, 7, 18, null, "Late", null },
                    { 19, 7, 19, 12.0m, "Completed", "path/to/completed/7_19.pdf" },
                    { 20, 7, 20, null, "Submitted", "path/to/submitted/7_20.pdf" },
                    { 21, 7, 21, null, "Late", null },
                    { 22, 7, 22, 11.0m, "Completed", "path/to/completed/7_22.pdf" },
                    { 23, 7, 23, null, "Submitted", "path/to/submitted/7_23.pdf" },
                    { 24, 7, 24, null, "Late", null },
                    { 25, 8, 1, 18.0m, "Completed", "path/to/completed/8_1.pdf" },
                    { 26, 8, 2, null, "Submitted", "path/to/submitted/8_2.pdf" },
                    { 27, 8, 3, null, "Late", null },
                    { 28, 8, 4, 17.0m, "Completed", "path/to/completed/8_4.pdf" },
                    { 29, 8, 5, null, "Submitted", "path/to/submitted/8_5.pdf" },
                    { 30, 8, 6, null, "Late", null },
                    { 31, 8, 7, 16.0m, "Completed", "path/to/completed/8_7.pdf" },
                    { 32, 8, 8, null, "Submitted", "path/to/submitted/8_8.pdf" },
                    { 33, 8, 9, null, "Late", null },
                    { 34, 8, 10, 15.0m, "Completed", "path/to/completed/8_10.pdf" },
                    { 35, 8, 11, null, "Submitted", "path/to/submitted/8_11.pdf" },
                    { 36, 8, 12, null, "Late", null },
                    { 37, 8, 13, 14.0m, "Completed", "path/to/completed/8_13.pdf" },
                    { 38, 8, 14, null, "Submitted", "path/to/submitted/8_14.pdf" },
                    { 39, 8, 15, null, "Late", null },
                    { 40, 8, 16, 13.0m, "Completed", "path/to/completed/8_16.pdf" },
                    { 41, 8, 17, null, "Submitted", "path/to/submitted/8_17.pdf" },
                    { 42, 8, 18, null, "Late", null },
                    { 43, 8, 19, 12.0m, "Completed", "path/to/completed/8_19.pdf" },
                    { 44, 8, 20, null, "Submitted", "path/to/submitted/8_20.pdf" },
                    { 45, 8, 21, null, "Late", null },
                    { 46, 8, 22, 11.0m, "Completed", "path/to/completed/8_22.pdf" },
                    { 47, 8, 23, null, "Submitted", "path/to/submitted/8_23.pdf" },
                    { 48, 8, 24, null, "Late", null },
                    { 49, 9, 1, 18.0m, "Completed", "path/to/completed/9_1.pdf" },
                    { 50, 9, 2, null, "Submitted", "path/to/submitted/9_2.pdf" },
                    { 51, 9, 3, null, "Late", null },
                    { 52, 9, 4, 17.0m, "Completed", "path/to/completed/9_4.pdf" },
                    { 53, 9, 5, null, "Submitted", "path/to/submitted/9_5.pdf" },
                    { 54, 9, 6, null, "Late", null },
                    { 55, 9, 7, 16.0m, "Completed", "path/to/completed/9_7.pdf" },
                    { 56, 9, 8, null, "Submitted", "path/to/submitted/9_8.pdf" },
                    { 57, 9, 9, null, "Late", null },
                    { 58, 9, 10, 15.0m, "Completed", "path/to/completed/9_10.pdf" },
                    { 59, 9, 11, null, "Submitted", "path/to/submitted/9_11.pdf" },
                    { 60, 9, 12, null, "Late", null },
                    { 61, 9, 13, 14.0m, "Completed", "path/to/completed/9_13.pdf" },
                    { 62, 9, 14, null, "Submitted", "path/to/submitted/9_14.pdf" },
                    { 63, 9, 15, null, "Late", null },
                    { 64, 9, 16, 13.0m, "Completed", "path/to/completed/9_16.pdf" },
                    { 65, 9, 17, null, "Submitted", "path/to/submitted/9_17.pdf" },
                    { 66, 9, 18, null, "Late", null },
                    { 67, 9, 19, 12.0m, "Completed", "path/to/completed/9_19.pdf" },
                    { 68, 9, 20, null, "Submitted", "path/to/submitted/9_20.pdf" },
                    { 69, 9, 21, null, "Late", null },
                    { 70, 9, 22, 11.0m, "Completed", "path/to/completed/9_22.pdf" },
                    { 71, 9, 23, null, "Submitted", "path/to/submitted/9_23.pdf" },
                    { 72, 9, 24, null, "Late", null },
                    { 73, 10, 1, 18.0m, "Completed", "path/to/completed/10_1.pdf" },
                    { 74, 10, 2, null, "Submitted", "path/to/submitted/10_2.pdf" },
                    { 75, 10, 3, null, "Late", null },
                    { 76, 10, 4, 17.0m, "Completed", "path/to/completed/10_4.pdf" },
                    { 77, 10, 5, null, "Submitted", "path/to/submitted/10_5.pdf" },
                    { 78, 10, 6, null, "Late", null },
                    { 79, 10, 7, 16.0m, "Completed", "path/to/completed/10_7.pdf" },
                    { 80, 10, 8, null, "Submitted", "path/to/submitted/10_8.pdf" },
                    { 81, 10, 9, null, "Late", null },
                    { 82, 10, 10, 15.0m, "Completed", "path/to/completed/10_10.pdf" },
                    { 83, 10, 11, null, "Submitted", "path/to/submitted/10_11.pdf" },
                    { 84, 10, 12, null, "Late", null },
                    { 85, 10, 13, 14.0m, "Completed", "path/to/completed/10_13.pdf" },
                    { 86, 10, 14, null, "Submitted", "path/to/submitted/10_14.pdf" },
                    { 87, 10, 15, null, "Late", null },
                    { 88, 10, 16, 13.0m, "Completed", "path/to/completed/10_16.pdf" },
                    { 89, 10, 17, null, "Submitted", "path/to/submitted/10_17.pdf" },
                    { 90, 10, 18, null, "Late", null },
                    { 91, 10, 19, 12.0m, "Completed", "path/to/completed/10_19.pdf" },
                    { 92, 10, 20, null, "Submitted", "path/to/submitted/10_20.pdf" },
                    { 93, 10, 21, null, "Late", null },
                    { 94, 10, 22, 11.0m, "Completed", "path/to/completed/10_22.pdf" },
                    { 95, 10, 23, null, "Submitted", "path/to/submitted/10_23.pdf" },
                    { 96, 10, 24, null, "Late", null },
                    { 97, 11, 1, 18.0m, "Completed", "path/to/completed/11_1.pdf" },
                    { 98, 11, 2, null, "Submitted", "path/to/submitted/11_2.pdf" },
                    { 99, 11, 3, null, "Late", null },
                    { 100, 11, 4, 17.0m, "Completed", "path/to/completed/11_4.pdf" },
                    { 101, 11, 5, null, "Submitted", "path/to/submitted/11_5.pdf" },
                    { 102, 11, 6, null, "Late", null },
                    { 103, 11, 7, 16.0m, "Completed", "path/to/completed/11_7.pdf" },
                    { 104, 11, 8, null, "Submitted", "path/to/submitted/11_8.pdf" },
                    { 105, 11, 9, null, "Late", null },
                    { 106, 11, 10, 15.0m, "Completed", "path/to/completed/11_10.pdf" },
                    { 107, 11, 11, null, "Submitted", "path/to/submitted/11_11.pdf" },
                    { 108, 11, 12, null, "Late", null },
                    { 109, 11, 13, 14.0m, "Completed", "path/to/completed/11_13.pdf" },
                    { 110, 11, 14, null, "Submitted", "path/to/submitted/11_14.pdf" },
                    { 111, 11, 15, null, "Late", null },
                    { 112, 11, 16, 13.0m, "Completed", "path/to/completed/11_16.pdf" },
                    { 113, 11, 17, null, "Submitted", "path/to/submitted/11_17.pdf" },
                    { 114, 11, 18, null, "Late", null },
                    { 115, 11, 19, 12.0m, "Completed", "path/to/completed/11_19.pdf" },
                    { 116, 11, 20, null, "Submitted", "path/to/submitted/11_20.pdf" },
                    { 117, 11, 21, null, "Late", null },
                    { 118, 11, 22, 11.0m, "Completed", "path/to/completed/11_22.pdf" },
                    { 119, 11, 23, null, "Submitted", "path/to/submitted/11_23.pdf" },
                    { 120, 11, 24, null, "Late", null },
                    { 121, 7, 25, null, "Active", null },
                    { 122, 8, 25, null, "Active", null },
                    { 123, 9, 25, null, "Active", null },
                    { 124, 10, 25, null, "Active", null },
                    { 125, 11, 25, null, "Active", null },
                    { 126, 7, 26, null, "Active", null },
                    { 127, 8, 26, null, "Active", null },
                    { 128, 9, 26, null, "Active", null },
                    { 129, 10, 26, null, "Active", null },
                    { 130, 11, 26, null, "Active", null },
                    { 131, 7, 27, null, "Active", null },
                    { 132, 8, 27, null, "Active", null },
                    { 133, 9, 27, null, "Active", null },
                    { 134, 10, 27, null, "Active", null },
                    { 135, 11, 27, null, "Active", null },
                    { 136, 7, 28, null, "Active", null },
                    { 137, 8, 28, null, "Active", null },
                    { 138, 9, 28, null, "Active", null },
                    { 139, 10, 28, null, "Active", null },
                    { 140, 11, 28, null, "Active", null },
                    { 141, 7, 29, null, "Active", null },
                    { 142, 8, 29, null, "Active", null },
                    { 143, 9, 29, null, "Active", null },
                    { 144, 10, 29, null, "Active", null },
                    { 145, 11, 29, null, "Active", null },
                    { 146, 7, 30, null, "Active", null },
                    { 147, 8, 30, null, "Active", null },
                    { 148, 9, 30, null, "Active", null },
                    { 149, 10, 30, null, "Active", null },
                    { 150, 11, 30, null, "Active", null },
                    { 151, 7, 31, null, "Active", null },
                    { 152, 8, 31, null, "Active", null },
                    { 153, 9, 31, null, "Active", null },
                    { 154, 10, 31, null, "Active", null },
                    { 155, 11, 31, null, "Active", null },
                    { 156, 7, 32, null, "Active", null },
                    { 157, 8, 32, null, "Active", null },
                    { 158, 9, 32, null, "Active", null },
                    { 159, 10, 32, null, "Active", null },
                    { 160, 11, 32, null, "Active", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 11 });

            for (int i = 1; i <= 160; i++)
            {
                migrationBuilder.DeleteData(
                    table: "StudentAssignment",
                    keyColumn: "Id",
                    keyValue: i);
            }

            for (int i = 1; i <= 31; i++)
            {
                migrationBuilder.DeleteData(
                    table: "CourseStudent",
                    keyColumn: "Id",
                    keyValue: i);
            }

            for (int i = 1; i <= 8; i++)
            {
                migrationBuilder.DeleteData(
                    table: "CourseInstructor",
                    keyColumn: "Id",
                    keyValue: i);
            }

            for (int i = 1; i <= 32; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Assignment",
                    keyColumn: "Id",
                    keyValue: i);
            }

            for (int i = 1; i <= 8; i++)
            {
                migrationBuilder.DeleteData(
                    table: "Course",
                    keyColumn: "Id",
                    keyValue: i);
            }

            for (int i = 2; i <= 11; i++)
            {
                migrationBuilder.DeleteData(
                    table: "AspNetUsers",
                    keyColumn: "Id",
                    keyValue: i);
            }
        }
    }
}
