using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IStudentAssignmentRepository
    {
        Task<StudentAssignment> GetByIdAsync(int id);
        Task<IEnumerable<StudentAssignment>> GetAllAsync();
        Task<IEnumerable<StudentAssignment>> GetByStudentIdAsync(int studentId);
        Task<IEnumerable<StudentAssignment>> GetByAssignmentIdAsync(int assignmentId);
        Task<bool> AddGradeAsync(int studentAssignmentId, decimal grade);
        Task<bool> SubmitAssignment(int studentAssignmentId, string filePath);
        Task<bool> AddAsync(int studentId, int assignmentId);
        Task<bool> UpdateAsync(StudentAssignment studentAssignment);
        Task<bool> DeleteAsync(int id);
        Task<bool> LateAssignment(int studentAssignmentId);
    }
}
