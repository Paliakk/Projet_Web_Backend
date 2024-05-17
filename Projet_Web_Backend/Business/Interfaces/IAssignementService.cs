using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAssignementService
    {
        Task<AssignementReadDTO> GetByIdAsync(int id);
        Task<IEnumerable<AssignementReadDTO>> GetAllAsync();
        Task<IEnumerable<AssignementReadWithCourseDTO>> GetAllWithCourse();
        Task<IEnumerable<AssignementReadDTO>> GetByCourseIdAsync(int courseId);
        Task<AssignementReadDTO> SearchByTitleAsync(string title);
        Task<Assignment> AddAsync(AssignementCreateDTO assignement);
        Task UpdateAsync(AssignementUpdateDTO assignement);
        Task<AssignementReadDTO> DeleteAsync(int assignementId);
        Task<CourseWithAssignmentsDTO> GetAssignmentsByCourseByInstructorId(int instructorId);
    }
}
