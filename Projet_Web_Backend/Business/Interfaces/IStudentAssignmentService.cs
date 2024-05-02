using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IStudentAssignmentService
    {
        Task<StudentAssignmentDTO> GetByIdAsync(int id);
        Task<IEnumerable<StudentAssignmentDTO>> GetAllAsync();
        Task<IEnumerable<StudentAssignmentDTO>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<StudentAssignmentDTO>> GetByAssignmentIdAsync(int assignmentId);
        Task<bool> AddGradeAsync(StudentAssignmentGradeDTO dto);
        Task<bool> AddAsync(int studentId, int assignmentId);
        Task<bool> UpdateAsync(StudentAssignmentUpdateDTO studentAssignmentDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<StudentAssignmentDTO>> GetAllWithCourseNameAsync(int studentId);
        Task<IEnumerable<StudentAssignmentDetailedDTO>> GetDetailedAssignmentsByStudentId(int studentId);
    }
}
