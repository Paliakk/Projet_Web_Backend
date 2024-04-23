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
using Humanizer;
using Data.Repositories;

namespace Business.Repositories
{
    public class StudentAssignmentService : IStudentAssignmentService
    {
        private readonly IStudentAssignmentRepository _studentAssignmentRrepository;
        private readonly IUserService _userService;
        private readonly IAssignementService _assignmentService;
        IMapper _mapper;
        public StudentAssignmentService(IStudentAssignmentRepository studentAssignmentRrepository, IMapper mapper, IUserService userService, IAssignementService assignementService)
        {
            _studentAssignmentRrepository = studentAssignmentRrepository;
            _mapper = mapper;
            _userService = userService;
            _assignmentService = assignementService;
        }
        public async Task<bool> AddAsync(int studentId, int assignmentId)
        {
            return await _studentAssignmentRrepository.AddAsync(studentId,assignmentId);
        }

        public async Task<bool> AddGradeAsync(StudentAssignmentGradeDTO dto)
        {
            return await _studentAssignmentRrepository.AddGradeAsync(dto.Id,dto.Grade);
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
            var studentAssignmentDTOs = _mapper.Map<IEnumerable<StudentAssignmentDTO>>(studentAssignments);
            foreach(var dto in studentAssignmentDTOs)
            {
                var userDTO = await _userService.GetUserById(dto.StudentId);
                if(userDTO != null)
                {
                    dto.studentName = userDTO.username;
                }
                var assignmentDTO = await _assignmentService.GetByIdAsync(dto.AssignmentId);
                if(assignmentDTO != null)
                {
                    dto.assignmentTitle = assignmentDTO.Title;
                }
            }
            return studentAssignmentDTOs;
        }

        public async Task<IEnumerable<StudentAssignmentDTO>> GetByAssignmentIdAsync(int assignmentId)
        {
            var studentAssignments = await _studentAssignmentRrepository.GetByAssignmentIdAsync(assignmentId);
            var studentAssignmentDTOs = _mapper.Map<IEnumerable<StudentAssignmentDTO>>(studentAssignments);
            foreach (var dto in studentAssignmentDTOs)
            {
                var userDTO = await _userService.GetUserById(dto.StudentId);
                if (userDTO != null)
                {
                    dto.studentName = userDTO.username;
                }
                var assignmentDTO = await _assignmentService.GetByIdAsync(dto.AssignmentId);
                if (assignmentDTO != null)
                {
                    dto.assignmentTitle = assignmentDTO.Title;
                }
            }
            return studentAssignmentDTOs;
        }

        public async Task<StudentAssignmentDTO> GetByIdAsync(int id)
        {
            var studentAssignment = await _studentAssignmentRrepository.GetByIdAsync(id);
            var studentAssignmentDTO = _mapper.Map<StudentAssignmentDTO>(studentAssignment);
            var userDTO = await _userService.GetUserById(studentAssignmentDTO.StudentId);
            if (userDTO != null)
            {
                studentAssignmentDTO.studentName = userDTO.username;
            }
            var assignmentDTO = await _assignmentService.GetByIdAsync(studentAssignmentDTO.AssignmentId);
            if (assignmentDTO != null)
            {
                studentAssignmentDTO.assignmentTitle = assignmentDTO.Title;
            }
            return studentAssignmentDTO;
        }

        public async Task<IEnumerable<StudentAssignmentDTO>> GetByStudentIdAsync(int studentId)
        {
            var studentAssignments = await _studentAssignmentRrepository.GetByStudentIdAsync(studentId);
            var studentAssignmentDTOs = _mapper.Map<IEnumerable<StudentAssignmentDTO>>(studentAssignments);
            foreach (var dto in studentAssignmentDTOs)
            {
                var userDTO = await _userService.GetUserById(dto.StudentId);
                if (userDTO != null)
                {
                    dto.studentName = userDTO.username;
                }
                var assignmentDTO = await _assignmentService.GetByIdAsync(dto.AssignmentId);
                if (assignmentDTO != null)
                {
                    dto.assignmentTitle = assignmentDTO.Title;
                }
            }
            return studentAssignmentDTOs;
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
