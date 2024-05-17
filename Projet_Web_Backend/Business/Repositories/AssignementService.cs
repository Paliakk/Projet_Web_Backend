using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class AssignementService : IAssignementService
    {
        private readonly IAssignementRepository _assignementRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentAssignmentRepository _studentAssignmentRepository;
        IMapper _mapper;
        public AssignementService(IAssignementRepository assignementRepository, ICourseRepository courseRepository,IStudentAssignmentRepository studentAssignmentRepository,IMapper mapper)
        {
            _assignementRepository = assignementRepository;
            _mapper = mapper;
            _courseRepository = courseRepository;
            _studentAssignmentRepository = studentAssignmentRepository;
        }
        public async Task<Assignment> AddAsync(AssignementCreateDTO assignement)
        {
            var assignementToAdd = _mapper.Map<Assignment>(assignement);
            var addedAssignment = await _assignementRepository.AddAsync(assignementToAdd);
            if (addedAssignment != null)
            {
                var students = await _courseRepository.GetStudentsByCourse(assignement.CourseId);
                foreach (var student in students)
                {
                    await _studentAssignmentRepository.AddAsync(student.Id, addedAssignment.Id);
                }
                return addedAssignment;
            }
            return null;
        }

        public async Task<AssignementReadDTO> DeleteAsync(int assignementId)
        {
            var assignement = await _assignementRepository.DeleteAsync(assignementId);
            if(assignement == null)
            {
                throw new KeyNotFoundException("Assignement non trouvé avec l'ID spécifié.");
            }
            return _mapper.Map<AssignementReadDTO>(assignement);
        }

        public async Task<IEnumerable<AssignementReadDTO>> GetAllAsync()
        {
            var assignements = await _assignementRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssignementReadDTO>>(assignements);
        }

        public async Task<AssignementReadDTO> GetByIdAsync(int id)
        {
            var assignement = await _assignementRepository.GetByIdAsync(id);
            return _mapper.Map<AssignementReadDTO>(assignement);
        }

        public async Task<IEnumerable<AssignementReadDTO>> GetByCourseIdAsync(int courseId)
        {
            var assignements = await _assignementRepository.GetByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<AssignementReadDTO>>(assignements);
        }

        public async Task<AssignementReadDTO> SearchByTitleAsync(string title)
        {
            var assignement = await _assignementRepository.SearchByTitleAsync(title);
            return _mapper.Map<AssignementReadDTO>(assignement);
        }

        public async Task UpdateAsync(AssignementUpdateDTO assignement)
        {
            var existingAssignement = await _assignementRepository.GetByIdAsync(assignement.Id);
            if (existingAssignement == null)
            {
                throw new KeyNotFoundException("Assignement non trouvé avec l'ID spécifié.");
            }
            if (existingAssignement.Id == assignement.Id)
            {
                var assignementToUpdate = _mapper.Map<Assignment>(assignement);
                assignementToUpdate.CourseId = existingAssignement.CourseId;
                await _assignementRepository.UpdateAsync(assignementToUpdate);
            }
        }
        public async Task<CourseWithAssignmentsDTO> GetAssignmentsByCourseByInstructorId(int instructorId)
        {
            var courses = await _courseRepository.GetCoursesByInstructorId(instructorId);

            var assignments = new List<AssignementReadDTO>();
            foreach(var course in courses)
            {
                var courseAssignments = await GetByCourseIdAsync(course.Id);
                assignments.AddRange(courseAssignments);
            }
            return new CourseWithAssignmentsDTO
            {
                Courses = _mapper.Map<IEnumerable<CourseDTO>>(courses),
                Assignments = assignments
            };
        }
        public async Task<IEnumerable<AssignementReadWithCourseDTO>> GetAllWithCourse()
        {
            var assignements = await _assignementRepository.GetAllAsync();
            var assignementsWithCourse = new List<AssignementReadWithCourseDTO>();
            foreach(var assignement in assignements)
            {
                 var withCourse = _mapper.Map<AssignementReadWithCourseDTO>(assignement);
                var course = await _courseRepository.GetCourseById(assignement.CourseId);
                if(course != null)
                {
                    withCourse.Id = assignement.Id;
                    withCourse.CourseId = assignement.CourseId;
                    withCourse.CourseName = course.Name;
                    withCourse.Title = assignement.Title;
                    withCourse.Description = assignement.Description;
                    withCourse.Deadline = assignement.Deadline;
                }
                assignementsWithCourse.Add(withCourse);
            }
            return assignementsWithCourse;
        }
    }
}
