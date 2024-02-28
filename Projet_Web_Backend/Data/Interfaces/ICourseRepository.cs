using Domain.Models;

namespace Data.Interfaces;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCourses();
    Task<Course> GetCourse(int courseId);
    Task<Course> AddCourse(Course course);
    Task<Course> UpdateCourse(Course course);
    Task<Course> GetCourseByName(string name);

    Task<IEnumerable<Student>> GetStudentsByCourse(int courseId);
    void DeleteCourse(Course course);
    Task<bool> AddStudentToCourse(int studentId, int courseId);
    Task<bool> RemoveStudentFromCourse(int studentId, int courseId);
    Task<bool> AddInstructorToCourse(int instructorId, int courseId);
    Task<bool> RemoveInstructorFromCourse(int instructorId, int courseId);
}
