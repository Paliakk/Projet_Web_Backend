using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Data;

public class BackendContext : DbContext
{
    public BackendContext(DbContextOptions<BackendContext> options) : base(options)
    {
    }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Students { get; set; }

    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<LocalUser> LocalUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasData(
            new Course { CourseId = 1, CourseName = "Web Development", CourseDescription = "Web Development is fun!" },
            new Course { CourseId = 2, CourseName = "Java Programming", CourseDescription = "Java Programming is fun! Fun! Fun! " },
            new Course { CourseId = 3, CourseName = "C# Programming", CourseDescription = "C# Programming is fun too!" },
            new Course { CourseId = 4, CourseName = "Data Structures", CourseDescription = "Learn about data structures." },
            new Course { CourseId = 5, CourseName = "Algorithms", CourseDescription = "Study the fundamentals of algorithms." },
            new Course { CourseId = 6, CourseName = "Computer Networks", CourseDescription = "Dive into computer networking principles." },
            new Course { CourseId = 7, CourseName = "Operating Systems", CourseDescription = "Explore how operating systems work." },
            new Course { CourseId = 8, CourseName = "Database Systems", CourseDescription = "Understand database management systems." }
        );
        modelBuilder.Entity<Student>().HasData(
            new Student { StudentId = 1, StudentUsername = "Igor" },
            new Student { StudentId = 2, StudentUsername = "Steven" },
            new Student { StudentId = 3, StudentUsername = "Damien" },
            new Student { StudentId = 4, StudentUsername = "AlexSmith" },
            new Student { StudentId = 5, StudentUsername = "JamieDoe" },
            new Student { StudentId = 6, StudentUsername = "ChrisJohnson" },
            new Student { StudentId = 7, StudentUsername = "PatTaylor" },
            new Student { StudentId = 8, StudentUsername = "SamBrown" }
        );
        modelBuilder.Entity<Instructor>().HasData(
            new Instructor { InstructorId = 1, InstructorUsername = "instructor1", },
            new Instructor { InstructorId = 2, InstructorUsername = "instructor2", },
            new Instructor { InstructorId = 3, InstructorUsername = "Dr. Jordan" },
            new Instructor { InstructorId = 4, InstructorUsername = "Prof. Morgan" },
            new Instructor { InstructorId = 5, InstructorUsername = "Dr. Casey" }
        );
        modelBuilder.Entity<Admin>().HasData(
            new Admin { AdminId = 1, AdminUsername = "admin1", },
            new Admin { AdminId = 2, AdminUsername = "admin2", }
        );
        // Le seedin de la table StudentCourse se fait via le fichier de migration car il est impossible d'utiliser "HasData" pour une table de jointure
    }
}