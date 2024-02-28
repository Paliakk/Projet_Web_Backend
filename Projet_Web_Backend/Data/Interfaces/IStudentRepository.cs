using Domain.Models;

namespace Data.Interfaces;

public interface IStudentRepository
{
    Task<ICollection<Student>> GetStudents();
    Task<Student> GetStudent(int studentId);
    Task<Student> AddStudent(Student student);
    Task<Student> UpdateStudent(Student student);
    Task<Student> GetStudentByUsername(string name);

    Task<IEnumerable<Course>> GetCoursesByStudent(int studentId);
    void DeleteStudent(Student student);
    bool StudentExists(int studentId);

}