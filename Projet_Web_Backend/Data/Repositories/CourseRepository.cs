using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Domain.Models;
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
    public async Task<IEnumerable<Course>> GetCourses()
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
    public async Task<Course?> UpdateCourse(Course course)
    {
        var existingCourse = await _context.Course.FirstOrDefaultAsync(c => c.Id == course.Id);
        if (existingCourse != null)
        {
            _context.Entry(existingCourse).CurrentValues.SetValues(course);
            await _context.SaveChangesAsync();
            return course;
        }
        return null;
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

    /*public async Task<IEnumerable<ApplicationUser>> GetStudentsByCourse(int courseId)
    {
        var coursesWithStudents = await _context.Course.
            Where(c => c.Id == courseId)
            .SelectMany(c => c.User)
            .ToListAsync();
        return coursesWithStudents;
    }*/
    public async Task<bool> AddStudentToCourse(int studentId, int courseId)
    {
        //Verif si l'user existe
        var user = await _context.Users.FindAsync(studentId);
        if (user == null)
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
        if (course == null)
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
            CourseID = courseId
        };
        _context.CourseStudent.Add(courseStudent);
        await _context.SaveChangesAsync();
        return true;
    }
    /*public async Task<bool> RemoveStudentFromCourse(int studentId, int courseId)
    {
        var course = await _context.Courses
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.CourseId == courseId);
        
        var student = await _context.Students.FindAsync(studentId);
        if (course == null || student == null)
        {
            return false;
        }
        if (!course.Students.Any(s=> s.StudentId == studentId))
        {
            return false;
        }
        course.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> AddInstructorToCourse(int instructorId, int courseId)
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