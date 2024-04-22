using AutoMapper;
using Business.Interfaces;
using Domain.Models;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Business.Repositories
{
    public class StudentAssignmentService : IStudentAssignmentService
    {
        private readonly IStudentAssignmentRepository _studentAssignmentRrepository;
        IMapper _mapper;
        public StudentAssignmentService(IStudentAssignmentRepository studentAssignmentRrepository, IMapper mapper)
        {
            _studentAssignmentRrepository = studentAssignmentRrepository;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(int studentId, int assignmentId)
        {
            return await _studentAssignmentRrepository.AddAsync(studentId,assignmentId);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var studentAssignmentToDelete = await _studentAssignmentRrepository.DeleteAsync(id);
            if (studentAssignmentToDelete == null)
            {
                throw new KeyNotFoundException("StudentAssignment non trouvé avec l'ID spécifié.");
            }
            return true;
        }

        public async Task<IEnumerable<StudentAssignmentDTO>> GetAllAsync()
        {
            var studentAssignments = await _studentAssignmentRrepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentAssignmentDTO>>(studentAssignments);
        }

        public async Task<IEnumerable<StudentAssignmentDTO>> GetByAssignmentIdAsync(int assignmentId)
        {
            var studentAssignments = await _studentAssignmentRrepository.GetByAssignmentIdAsync(assignmentId);
            return _mapper.Map<IEnumerable<StudentAssignmentDTO>>(studentAssignments);
        }

        public async Task<StudentAssignmentDTO> GetByIdAsync(int id)
        {
            var studentAssignment = await _studentAssignmentRrepository.GetByIdAsync(id);
            return _mapper.Map<StudentAssignmentDTO>(studentAssignment);
        }

        public async Task<IEnumerable<StudentAssignmentDTO>> GetByStudentIdAsync(int studentId)
        {
            var studentAssignments = await _studentAssignmentRrepository.GetByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<StudentAssignmentDTO>>(studentAssignments);
        }

        public async Task<bool> UpdateAsync(StudentAssignmentUpdateDTO studentAssignmentDto)
        {
            var existingStudentAssignment = await _studentAssignmentRrepository.GetByIdAsync(studentAssignmentDto.Id);
            if (existingStudentAssignment == null)
            {
                throw new KeyNotFoundException("StudentAssignment non trouvé avec l'ID spécifié.");
            }
            if (existingStudentAssignment.Id == studentAssignmentDto.Id)
            {
                var studentAssignmentToUpdate = _mapper.Map<StudentAssignment>(studentAssignmentDto);
                await _studentAssignmentRrepository.UpdateAsync(studentAssignmentToUpdate);
                return true;
            }   
            return false;
        }
    }
}
