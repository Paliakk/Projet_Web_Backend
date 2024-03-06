using Data.Data;
using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly BackendContext _context;

    public CourseRepository(BackendContext dbContext)
    {
        _context = dbContext;
    }
    public async Task<IEnumerable<Course>> GetCourses()
    {
        return await _context.Courses.ToListAsync();      //CHangement de la méthode pour qu'elle retourne les cours par ordre croissant
    }
    public async Task<Course?> GetCourseById(int id)
    {
        return await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == id);
    }
    public async Task<Course> AddCourse(Course course)
    {
        var result = await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<Course?> UpdateCourse(Course course)
    {
        var existingCourse = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == course.CourseId);
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
        var existingCourse = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
        if(existingCourse is null)
        {
            return null;
        }
        _context.Courses.Remove(existingCourse);
        await _context.SaveChangesAsync();
        return existingCourse;
    }

    public async Task<IEnumerable<Student>> GetStudentsByCourse(int courseId)
    {
        var coursesWithStudents = await _context.Courses.
            Where(c => c.CourseId == courseId)
            .SelectMany(c => c.Students)
            .ToListAsync();
        return coursesWithStudents;
    }
    public async Task<bool> AddStudentToCourse(int studentId, int courseId)
    {
        var course = await _context.Courses
            .Include(c => c.Students)
            .FirstOrDefaultAsync(c => c.CourseId == courseId);
        
        var student = await _context.Students.FindAsync(studentId);
        if (course == null || student == null)
        {
            return false;
        }
        if (course.Students.Any(s=> s.StudentId == studentId))
        {
            return false;
        }
        course.Students.Add(student);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> RemoveStudentFromCourse(int studentId, int courseId)
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
    }
}