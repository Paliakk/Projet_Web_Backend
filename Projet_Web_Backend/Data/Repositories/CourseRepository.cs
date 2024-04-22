using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Data.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AuthDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<ApplicationRole> _roleManager;

    public CourseRepository(AuthDbContext dbContext, RoleManager<ApplicationRole> roleManager,UserManager<ApplicationUser> userManager)
    {
        _context = dbContext;
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public async Task<IEnumerable<Course>> GetAllCourses()
    {
        return await _context.Course.ToListAsync();      //CHangement de la méthode pour qu'elle retourne les cours par ordre croissant
    }
    public async Task<Course?> GetCourseById(int id)
    {
        return await _context.Course.FirstOrDefaultAsync(c => c.Id == id);
    }
    public async Task<Course> AddCourse(Course course)
    {
        var result = await _context.Course.AddAsync(course); 
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task UpdateCourse(Course course)
    {
        var existingCourse = await _context.Course.FirstOrDefaultAsync(c => c.Id == course.Id);
        if (existingCourse != null)
        {
            _context.Entry(existingCourse).CurrentValues.SetValues(course);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<Course?> DeleteCourse(int courseId)            // J'ai aussi eu pas mal de problèmes sur la suppression je ne passais que l'id maintenant je passe un course complet
    {
        var existingCourse = await _context.Course.FirstOrDefaultAsync(c => c.Id == courseId);
        if(existingCourse is null)
        {
            return null;
        }
        _context.Course.Remove(existingCourse);
        await _context.SaveChangesAsync();
        return existingCourse;
    }

    public async Task<IEnumerable<ApplicationUser?>> GetStudentsByCourse(int courseId)
    {
        var coursesWithStudents = await _context.CourseStudent.
            Where(cs => cs.CourseID == courseId)
            .Include(cs => cs.User)
            .ToListAsync();
        var students = coursesWithStudents.
            Where(cs=>cs.User!=null)
            .Select(cs=>cs.User)
            .ToList();
        return students;
    }
    public async Task<IEnumerable<ApplicationUser?>> GetInstructorBycourse(int courseId)
    {
        var courseWithInstructor = await _context.CourseInstructor
            .Where (ci=> ci.CourseID == courseId)
            .Include(ci => ci.User)
            .ToListAsync();
        var instructors = courseWithInstructor
            .Where (ci => ci.User != null)
            .Select (ci=>ci.User)
            .ToList();
        return instructors;
    }
    public async Task<IEnumerable<Course?>> GetCoursesByInstructorName(string instructorName)
    {
        var coursesWithInstructor = await _context.CourseInstructor
            .Where(ci => ci.username.Equals(instructorName))
            .Select(ci=>ci.Course)
            .Where(c=> c !=null)
            .ToListAsync();
        return coursesWithInstructor;
    }
    public async Task<IEnumerable<Course?>> GetCoursesByStudentId(int studentId)
    {
        var courses = await _context.CourseStudent
        .Where(cs => cs.UserID == studentId)
        .Select(cs => cs.Course)
        .Where(c => c != null)
        .ToListAsync();

        return courses;
    }
    public async Task<bool> AddStudentToCourse(int studentId, int courseId)
    {
        //Verif si l'user existe
        var user = await _context.Users.FindAsync(studentId);
        if (user == null || user.UserName == null)
        {
            return false;
        }
        //Vérif si user à le rôle student
        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains("Student"))
        {
            return false;
        }
        //vérif si cours existe
        var course = await _context.Course.FindAsync(courseId);
        if (course == null || course.Name == null)
        {
            return false;
        }
        //Vérif si user inscrit au cours
        bool isAlreadyEnrolle = _context.CourseStudent.Any(cs => cs.UserID == studentId && cs.CourseID == courseId);
        if (isAlreadyEnrolle)
        {
            return false;
        }
        //Ajouter l'user
        var courseStudent = new CourseStudent
        {
            UserID = studentId,
            CourseID = courseId,
            CourseName = course.Name,
            username = user.UserName

        };
        _context.CourseStudent.Add(courseStudent);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> AddInstructorToCourse(int instructorId, int courseId)
    {
        //Verif si l'user existe
        var user = await _context.Users.FindAsync(instructorId);
        if (user == null || user.UserName == null)
        {
            return false;
        }
        //Vérif si user à le rôle instructor
        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Contains("Instructor"))
        {
            return false;
        }
        //vérif si cours existe
        var course = await _context.Course.FindAsync(courseId);
        if (course == null || course.Name == null)
        {
            return false;
        }
        //Vérif si user inscrit au cours
        bool isAlreadyInstructor = _context.CourseInstructor.Any(cs => cs.UserID == instructorId && cs.CourseID == courseId);
        if (isAlreadyInstructor)
        {
            return false;
        }
        //Ajouter l'user
        var courseInstructor = new CourseInstructor
        {
            UserID = instructorId,
            CourseID = courseId,
            CourseName = course.Name,
            username = user.UserName

        };
        _context.CourseInstructor.Add(courseInstructor);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveStudentFromCourse(int studentId, int courseId)
    {
        //Trouver la relation CourseStudent existante
        var courseStudent = await _context.CourseStudent
            .FirstOrDefaultAsync(cs => cs.UserID == studentId && cs.CourseID == courseId);
        //Vérification nullité
        if(courseStudent == null)
        {
            return false;
        }
        //Supprimer la relation si existante
        _context.CourseStudent.Remove(courseStudent);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveInstructorFromCourse(int instructorId, int courseId)
    {
        var courseInstructor = await _context.CourseInstructor
            .FirstOrDefaultAsync(ci => ci.UserID == instructorId && ci.CourseID == courseId);
        if( courseInstructor == null) { return false; }
        _context.CourseInstructor.Remove(courseInstructor);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> UpdateCourseInstructor(int courseId, string instructorName)
    {
        var courseInstructor = await _context.CourseInstructor
            .Where (ci => ci.CourseID == courseId)
            .FirstOrDefaultAsync();
        var newInstructor = await _userManager.Users
            .Where(i => i.UserName == instructorName)
            .FirstOrDefaultAsync();

        if (courseInstructor == null)
        {
            throw new Exception("Course not found");
        }

        if (newInstructor == null)
        {
            return false;  // Ajout d'un check pour newInstructor avant de l'utiliser.
        }
        courseInstructor.username = instructorName;
        courseInstructor.UserID = newInstructor.Id;
        await _context.SaveChangesAsync(); 
        return true;
    }
    public async Task<bool> RemoveAllStudentsFromCourse(int courseId)
    {
        //Trouver les CourseStudent liés au courseId
        var courseStudents = await _context.CourseStudent
            .Where(cs=> cs.CourseID == courseId)
            .ToListAsync();
        //Vérifier s'il y a des étudiants
        if (!courseStudents.Any())
        {
            return false;
        }
        //Suppression
        _context.CourseStudent.RemoveRange(courseStudents);
        await _context.SaveChangesAsync(); return true;
    }
    /*public async Task<bool> AddInstructorToCourse(int instructorId, int courseId)
    {
        var course = await _context.Courses
            .Include(c => c.Instructors)
            .FirstOrDefaultAsync(c => c.CourseId == courseId);
        
        var instructor = await _context.Instructors.FindAsync(instructorId);
        if (course == null || instructor == null)
        {
            return false;
        }
        if (course.Instructors.Any(i=> i.InstructorId == instructorId))
        {
            return false;
        }
        course.Instructors.Add(instructor);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveInstructorFromCourse(int instructorId, int courseId)
    {
        var course = await _context.Courses
            .Include(c => c.Instructors)
            .FirstOrDefaultAsync(c => c.CourseId == courseId);
        
        var instructor = await _context.Instructors.FindAsync(instructorId);
        if (course == null || instructor == null)
        {
            return false;
        }
        if (!course.Instructors.Any(i=> i.InstructorId == instructorId))
        {
            return false;
        }
        course.Instructors.Remove(instructor);
        await _context.SaveChangesAsync();
        return true;
    }*/
}