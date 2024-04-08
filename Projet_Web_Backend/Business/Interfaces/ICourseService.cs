using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAllCourses();
        Task<CourseDTO?> GetCourseById(int courseId);
        Task<Course> AddCourse(CourseCreateDTO createDTO);
        Task UpdateCourse(CourseDTO course);
        Task<CourseDTO> DeleteCourse(int courseId);
        Task<bool> AddStudentToCourse(int studentId, int courseId);
        Task<bool> RemoveStudentFromCourse(int studentId, int courseId);
        Task<bool> RemoveInstructorFromCourse(int instructorId, int courseId);
        Task<IEnumerable<UserDTO>> GetStudentsByCourse(int courseId);
        Task<IEnumerable<UserDTO>> GetInstructorBycourse(int courseId);
        Task<IEnumerable<CourseDTO>> GetCoursesByStudentId(int studentId);
        Task<bool> AddInstructorToCourse(int instructorId, int courseId);
        Task<IEnumerable<CourseDTO>> GetCoursesByInstructorName(string instructorName);
        Task<bool> UpdateCourseInstructor(int courseId, string instructorName);
        Task<bool> RemoveAllStudentsFromCourse(int courseId);

    }
}
