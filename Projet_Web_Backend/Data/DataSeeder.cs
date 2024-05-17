using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataSeeder
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DataSeeder(AuthDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();

            // Seed roles
            var roles = new List<ApplicationRole>
        {
            new ApplicationRole { Name = "Student" },
            new ApplicationRole { Name = "Admin" },
            new ApplicationRole { Name = "Instructor" }
        };

            foreach (var role in roles)
            {
                if (!await _roleManager.RoleExistsAsync(role.Name))
                {
                    await _roleManager.CreateAsync(role);
                }
            }

            // Seed admin user
            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@ephec.be",
                NormalizedEmail = "ADMIN@EPHEC.BE",
                NormalizedUserName = "ADMIN",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            if (await _userManager.FindByNameAsync(adminUser.UserName) == null)
            {
                await _userManager.CreateAsync(adminUser, "Admin123");
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Seed instructors
            var instructors = new List<ApplicationUser>
        {
            new ApplicationUser { UserName = "johndoe", Email = "john.doe@ephec.be", NormalizedEmail = "JOHN.DOE@EPHEC.BE", NormalizedUserName = "JOHNDOE", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "janedoe", Email = "jane.doe@ephec.be", NormalizedEmail = "JANE.DOE@EPHEC.BE", NormalizedUserName = "JANEDOE", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "robertsmith", Email = "robert.smith@ephec.be", NormalizedEmail = "ROBERT.SMITH@EPHEC.BE", NormalizedUserName = "ROBERTSMITH", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "lindajohnson", Email = "linda.johnson@ephec.be", NormalizedEmail = "LINDA.JOHNSON@EPHEC.BE", NormalizedUserName = "LINDAJOHNSON", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "michaelbrown", Email = "michael.brown@ephec.be", NormalizedEmail = "MICHAEL.BROWN@EPHEC.BE", NormalizedUserName = "MICHAELBROWN", SecurityStamp = Guid.NewGuid().ToString("D") }
        };

            foreach (var instructor in instructors)
            {
                if (await _userManager.FindByNameAsync(instructor.UserName) == null)
                {
                    await _userManager.CreateAsync(instructor, "Instructor123");
                    await _userManager.AddToRoleAsync(instructor, "Instructor");
                }
            }

            // Seed students
            var students = new List<ApplicationUser>
        {
            new ApplicationUser { UserName = "alicewilliams", Email = "alice.williams@ephec.be", NormalizedEmail = "ALICE.WILLIAMS@EPHEC.BE", NormalizedUserName = "ALICEWILLIAMS", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "jamesjones", Email = "james.jones@ephec.be", NormalizedEmail = "JAMES.JONES@EPHEC.BE", NormalizedUserName = "JAMESJONES", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "emilydavis", Email = "emily.davis@ephec.be", NormalizedEmail = "EMILY.DAVIS@EPHEC.BE", NormalizedUserName = "EMILYDAVIS", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "williamwilson", Email = "william.wilson@ephec.be", NormalizedEmail = "WILLIAM.WILSON@EPHEC.BE", NormalizedUserName = "WILLIAMWILSON", SecurityStamp = Guid.NewGuid().ToString("D") },
            new ApplicationUser { UserName = "sophiamiller", Email = "sophia.miller@ephec.be", NormalizedEmail = "SOPHIA.MILLER@EPHEC.BE", NormalizedUserName = "SOPHIAMILLER", SecurityStamp = Guid.NewGuid().ToString("D") }
        };

            foreach (var student in students)
            {
                if (await _userManager.FindByNameAsync(student.UserName) == null)
                {
                    await _userManager.CreateAsync(student, "Student123");
                    await _userManager.AddToRoleAsync(student, "Student");
                }
            }

            // Seed courses
            var courses = new List<Course>
        {
            new Course { Name = "Web Development", Description = "Web Development is fun!" },
            new Course { Name = "Java Programming", Description = "Java Programming is fun! Fun! Fun! " },
            new Course { Name = "C# Programming", Description = "C# Programming is fun too!" },
            new Course { Name = "Data Structures", Description = "Learn about data structures." },
            new Course { Name = "Algorithms", Description = "Study the fundamentals of algorithms." },
            new Course { Name = "Computer Networks", Description = "Dive into computer networking principles." },
            new Course { Name = "Operating Systems", Description = "Explore how operating systems work." },
            new Course { Name = "Database Systems", Description = "Understand database management systems." }
        };

            if (!_context.Course.Any())
            {
                _context.Course.AddRange(courses);
                await _context.SaveChangesAsync();
            }

            // Seed assignments
            var assignments = new List<Assignment>
        {
            // Web Development
            new Assignment { CourseId = 1, Title = "HTML Basics", Description = "Introduction to HTML", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 1, Title = "CSS Styling", Description = "Learn to style with CSS", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 1, Title = "JavaScript Fundamentals", Description = "Basic JavaScript concepts", Deadline = DateTime.Now.AddDays(21) },
            
            // Java Programming
            new Assignment { CourseId = 2, Title = "Java Syntax", Description = "Learn the syntax of Java", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 2, Title = "OOP in Java", Description = "Object-Oriented Programming concepts", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 2, Title = "Java Collections", Description = "Explore Java Collections Framework", Deadline = DateTime.Now.AddDays(21) },

            // C# Programming
            new Assignment { CourseId = 3, Title = "C# Basics", Description = "Introduction to C#", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 3, Title = "LINQ", Description = "Language Integrated Query in C#", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 3, Title = "Async Programming", Description = "Asynchronous programming in C#", Deadline = DateTime.Now.AddDays(21) },

            // Data Structures
            new Assignment { CourseId = 4, Title = "Arrays and Lists", Description = "Basic data structures", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 4, Title = "Trees and Graphs", Description = "Advanced data structures", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 4, Title = "Hash Tables", Description = "Understanding hash tables", Deadline = DateTime.Now.AddDays(21) },

            // Algorithms
            new Assignment { CourseId = 5, Title = "Sorting Algorithms", Description = "Basic sorting techniques", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 5, Title = "Search Algorithms", Description = "Introduction to searching", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 5, Title = "Dynamic Programming", Description = "Advanced algorithmic techniques", Deadline = DateTime.Now.AddDays(21) },

            // Computer Networks
            new Assignment { CourseId = 6, Title = "Network Basics", Description = "Introduction to networking", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 6, Title = "TCP/IP Protocol", Description = "Understanding TCP/IP", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 6, Title = "Network Security", Description = "Basics of network security", Deadline = DateTime.Now.AddDays(21) },

            // Operating Systems
            new Assignment { CourseId = 7, Title = "OS Fundamentals", Description = "Basic concepts of OS", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 7, Title = "Process Management", Description = "Understanding processes", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 7, Title = "Memory Management", Description = "How OS manages memory", Deadline = DateTime.Now.AddDays(21) },

            // Database Systems
            new Assignment { CourseId = 8, Title = "SQL Basics", Description = "Introduction to SQL", Deadline = DateTime.Now.AddDays(-7) },
            new Assignment { CourseId = 8, Title = "Normalization", Description = "Database normalization techniques", Deadline = DateTime.Now.AddDays(14) },
            new Assignment { CourseId = 8, Title = "Indexing", Description = "Optimizing database performance", Deadline = DateTime.Now.AddDays(21) }
        };

            if (!_context.Assignment.Any())
            {
                _context.Assignment.AddRange(assignments);
                await _context.SaveChangesAsync();
            }

            // Seed course instructors
            var courseInstructors = new List<CourseInstructor>
        {
            new CourseInstructor { UserID = 2, username = "johndoe", CourseID = 1, CourseName = "Web Development" },
            new CourseInstructor { UserID = 2, username = "johndoe", CourseID = 2, CourseName = "Java Programming" },
            new CourseInstructor { UserID = 2, username = "johndoe", CourseID = 3, CourseName = "C# Programming" },
            new CourseInstructor { UserID = 3, username = "janedoe", CourseID = 4, CourseName = "Data Structures" },
            new CourseInstructor { UserID = 3, username = "janedoe", CourseID = 5, CourseName = "Algorithms" },
            new CourseInstructor { UserID = 4, username = "robertsmith", CourseID = 6, CourseName = "Computer Networks" },
            new CourseInstructor { UserID = 5, username = "lindajohnson", CourseID = 7, CourseName = "Operating Systems" },
            new CourseInstructor { UserID = 6, username = "michaelbrown", CourseID = 8, CourseName = "Database Systems" }
        };

            if (!_context.CourseInstructor.Any())
            {
                _context.CourseInstructor.AddRange(courseInstructors);
                await _context.SaveChangesAsync();
            }

            // Seed course students
            var courseStudents = new List<CourseStudent>();

            // Student 1 is enrolled in all courses
            for (int i = 1; i <= 8; i++)
            {
                courseStudents.Add(new CourseStudent { UserID = 7, username = "alicewilliams", CourseID = i, CourseName = assignments.First(a => a.CourseId == i).Course.Name });
            }

            // Other students are enrolled in 5 or 6 courses
            int courseStudentId = 9;
            for (int studentId = 8; studentId <= 11; studentId++)
            {
                for (int courseId = 1; courseId <= 6; courseId++)
                {
                    if (courseId % 6 != studentId - 7)
                    {
                        courseStudents.Add(new CourseStudent { UserID = studentId, username = students.First(s => s.Id == studentId).UserName, CourseID = courseId, CourseName = assignments.First(a => a.CourseId == courseId).Course.Name });
                    }
                }
            }

            if (!_context.CourseStudent.Any())
            {
                _context.CourseStudent.AddRange(courseStudents);
                await _context.SaveChangesAsync();
            }

            // Seed student assignments
            var studentAssignments = new List<StudentAssignment>();
            var random = new Random();
            int studentAssignmentId = 1;

            foreach (var courseStudent in courseStudents)
            {
                var assignmentsForCourse = assignments.Where(a => a.CourseId == courseStudent.CourseID).ToList();

                // Each student has one completed, one submitted, and the late assignment
                studentAssignments.Add(new StudentAssignment
                {
                    StudentId = courseStudent.UserID,
                    AssignmentId = assignmentsForCourse[0].Id,
                    Grade = random.Next(10, 20),
                    Status = "Completed",
                    FilePath = $"path/to/completed/{courseStudent.UserID}_{assignmentsForCourse[0].Id}.pdf"
                });

                studentAssignments.Add(new StudentAssignment
                {
                    StudentId = courseStudent.UserID,
                    AssignmentId = assignmentsForCourse[1].Id,
                    Grade = null,
                    Status = "Submitted",
                    FilePath = $"path/to/submitted/{courseStudent.UserID}_{assignmentsForCourse[1].Id}.pdf"
                });

                studentAssignments.Add(new StudentAssignment
                {
                    StudentId = courseStudent.UserID,
                    AssignmentId = assignmentsForCourse[2].Id,
                    Grade = null,
                    Status = "Late",
                    FilePath = null
                });
            }

            if (!_context.StudentAssignment.Any())
            {
                _context.StudentAssignment.AddRange(studentAssignments);
                await _context.SaveChangesAsync();
            }
        }
    }
}
