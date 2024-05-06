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
        private readonly ICourseRepository _courseRepository;
        IMapper _mapper;
        public StudentAssignmentService(IStudentAssignmentRepository studentAssignmentRrepository, IMapper mapper, IUserService userService, IAssignementService assignementService, ICourseRepository courseRepository)
        {
            _studentAssignmentRrepository = studentAssignmentRrepository;
            _mapper = mapper;
            _userService = userService;
            _assignmentService = assignementService;
            _courseRepository = courseRepository;
        }
        public async Task<bool> AddAsync(int studentId, int assignmentId)
        {
            return await _studentAssignmentRrepository.AddAsync(studentId,assignmentId);
        }

        public async Task<bool> AddGradeAsync(StudentAssignmentGradeDTO dto)
        {
            return await _studentAssignmentRrepository.AddGradeAsync(dto.Id,dto.Grade);
        }

        public async Task<bool> SubmitAssignment(int studentAssignmentId, string filePath)
        {
            //Ici implémenter la logique pour manipuler le fichier si j'ai le temps
            return await _studentAssignmentRrepository.SubmitAssignment(studentAssignmentId,filePath);
        }
        public async Task<bool> LateAssignment(int studentAssignmentId)
        {
            return await _studentAssignmentRrepository.LateAssignment(studentAssignmentId);
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

        public async Task<IEnumerable<StudentAssignmentDetailedDTO>> GetAllAsync()
        {
            var studentAssignments = await _studentAssignmentRrepository.GetAllAsync();
            var detailedAssignments = new List<StudentAssignmentDetailedDTO>();

            foreach (var sa in studentAssignments)
            {
                var detailedDto = _mapper.Map<StudentAssignmentDetailedDTO>(sa);

                var userDTO = await _userService.GetUserById(sa.StudentId);
                if (userDTO != null)
                {
                    detailedDto.studentName = userDTO.username;
                }

                var assignment = await _assignmentService.GetByIdAsync(sa.AssignmentId);
                if (assignment != null)
                {
                    detailedDto.AssignmentTitle = assignment.Title;
                    detailedDto.AssignmentDescription = assignment.Description;
                    detailedDto.AssignmentDeadline = assignment.Deadline;
                    detailedDto.courseId = assignment.CourseId;

                    var course = await _courseRepository.GetCourseById(assignment.CourseId);
                    if (course != null)
                    {
                        detailedDto.CourseName = course.Name;
                    }
                }

                detailedAssignments.Add(detailedDto);
            }

            return detailedAssignments;
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
                studentAssignmentDTO.courseId = assignmentDTO.CourseId;
                studentAssignmentDTO.CourseName = (await _courseRepository.GetCourseById(assignmentDTO.CourseId)).Name;
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
        public async Task<IEnumerable<StudentAssignmentDTO>> GetAllWithCourseNameAsync(int studentId)
        {
            var studentAssignments = await _studentAssignmentRrepository.GetByStudentIdAsync(studentId);
            var studentAssignmentDTOs = _mapper.Map<IEnumerable<StudentAssignmentDTO>>(studentAssignments);

            foreach( var dto in studentAssignmentDTOs)
            {
                var userDTO = await _userService.GetUserById(dto.StudentId);
                if (userDTO != null)
                {
                    dto.studentName = userDTO.username;
                }
                var assignmentDTO = await _assignmentService.GetByIdAsync(dto.AssignmentId);
                if(assignmentDTO != null)
                {
                    dto.assignmentTitle = assignmentDTO.Title;
                    var courseDTO = await _courseRepository.GetCourseById(assignmentDTO.CourseId);
                    if (courseDTO != null)
                    {
                        dto.CourseName = courseDTO.Name;
                        dto.courseId = courseDTO.Id;
                    }
                }
            }
            return studentAssignmentDTOs;
        }
        public async Task<IEnumerable<StudentAssignmentDetailedDTO>> GetDetailedAssignmentsByStudentId(int studentId)
        {
            var studentAssignments = await _studentAssignmentRrepository.GetByStudentIdAsync(studentId);
            var detailedAssignments = new List<StudentAssignmentDetailedDTO>();

            foreach(var sa in studentAssignments)
            {
                var detailedDto = _mapper.Map<StudentAssignmentDetailedDTO>(sa);

                var assignment = await _assignmentService.GetByIdAsync(sa.AssignmentId);
                if(assignment != null)
                {
                    detailedDto.AssignmentTitle = assignment.Title;
                    detailedDto.AssignmentDescription = assignment.Description;
                    detailedDto.AssignmentDeadline = assignment.Deadline;
                    detailedDto.courseId = assignment.CourseId;

                    var course = await _courseRepository.GetCourseById(assignment.CourseId);
                    if(course != null)
                    {
                        detailedDto.CourseName = course.Name;
                    }
                    detailedAssignments.Add(detailedDto);
                }
            }
            return detailedAssignments;

        }
    }
}
