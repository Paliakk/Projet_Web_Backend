using Domain.Dtos;
using Domain.Models;

namespace Data.Interfaces;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllCourses();
    Task<Course?> GetCourseById(int courseId);
    Task<Course> AddCourse(Course course);
    Task UpdateCourse(Course course);
    Task<Course?> DeleteCourse(int courseId);
    Task<bool> AddStudentToCourse(int studentId, int courseId);
    Task<IEnumerable<ApplicationUser>> GetStudentsByCourse(int courseId);
    Task<IEnumerable<ApplicationUser>> GetInstructorBycourse(int courseId);
    Task<IEnumerable<Course>> GetCoursesByStudentId(int studentId);
    Task<bool> RemoveStudentFromCourse(int studentId, int courseId);
    Task<bool> RemoveInstructorFromCourse(int instructorId, int courseId);
    Task<bool> AddInstructorToCourse(int instructorId, int courseId);
    Task<IEnumerable<Course>> GetCoursesByInstructorName(string instructorName);
    Task<bool> UpdateCourseInstructor(int courseId, string instructorName);
    Task<bool> RemoveAllStudentsFromCourse(int courseId);
    //Task<bool> AddInstructorToCourse(int instructorId, int courseId);
    //Task<bool> RemoveInstructorFromCourse(int instructorId, int courseId);
    
}
