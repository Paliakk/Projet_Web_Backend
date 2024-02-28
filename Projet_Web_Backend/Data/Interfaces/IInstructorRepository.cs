using Domain.Models;

namespace Data.Interfaces;

public interface IInstructorRepository
{
    Task<IEnumerable<Instructor>> GetInstructors();
    Task<Instructor> GetInstructor(int instructorId);
    Task<Instructor> AddInstructor(Instructor instructor);
    Task<Instructor> UpdateInstructor(Instructor instructor);
    Task<Instructor> GetInstructorByUsername(string name);

    IEnumerable<Course> GetCoursesByInstructor(int instructorId);
    void DeleteInstructor(Instructor instructor);
}
