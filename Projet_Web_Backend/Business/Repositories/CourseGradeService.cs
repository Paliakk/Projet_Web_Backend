using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class CourseGradeService : ICourseGradeService
    {
        /*private readonly IGradeCourseRepository _gradeCourseRepository;
        private readonly IAssignementRepository _assignementRepository;
        IMapper _mapper;

        public CourseGradeService(IGradeCourseRepository gradeCourseRepository, IAssignementRepository assignementRepository,IMapper mapper)
        {
            _gradeCourseRepository = gradeCourseRepository;
            _assignementRepository = assignementRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(GradeCourseCreateDto courseGrade)
        {
            var gradeCourseToAdd = _mapper.Map<GradeCourse>(courseGrade);
            var addedGradeCourse = await _gradeCourseRepository.AddAsync(gradeCourseToAdd);
            return _mapper.Map<GradeCourseCreateDto>(addedGradeCourse) != null;
        }

        public async Task<bool> DeleteAsync(int courseGradeId)
        {
            var gradeCourseToDelete = await _gradeCourseRepository.DeleteAsync(courseGradeId);
            if(gradeCourseToDelete == null)
            {
                throw new KeyNotFoundException("GradeCourse non trouvé avec l'ID spécifié.");
            }
            return true;
        }

        public async Task<IEnumerable<GradeCourseReadDto>> GetAllAsync()
        {
            var gradeCourses = await _gradeCourseRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GradeCourseReadDto>>(gradeCourses);
        }

        public async Task<IEnumerable<GradeCourseReadDto>> GetByAssignmentIdAsync(int assignmentId)
        {
            var gradeCourses = await _gradeCourseRepository.GetByAssignmentIdAsync(assignmentId);
            return _mapper.Map<IEnumerable<GradeCourseReadDto>>(gradeCourses);
        }

        public async Task<IEnumerable<GradeCourseReadDto>> GetByCourseIdAsync(int courseId)
        {
            var gradeCourses = await _gradeCourseRepository.GetByCourseIdAsync(courseId);
            return _mapper.Map<IEnumerable<GradeCourseReadDto>>(gradeCourses);
        }

        public async Task<GradeCourseReadDto> GetByIdAsync(int courseGradeId)
        {
            var gradeCourse = await _gradeCourseRepository.GetByIdAsync(courseGradeId);
            return _mapper.Map<GradeCourseReadDto>(gradeCourse);
        }

        public async Task<IEnumerable<GradeCourseReadDto>> GetByStudentIdAsync(int studentId)
        {
            var gradeCourses = await _gradeCourseRepository.GetByStudentIdAsync(studentId);
            return _mapper.Map<IEnumerable<GradeCourseReadDto>>(gradeCourses);
        }

        public async Task<bool> UpdateAsync(GradeCourseUpdateDto courseGrade)
        {
            var existingGradeCourse = await _gradeCourseRepository.GetByIdAsync(courseGrade.Id);
            if (existingGradeCourse == null)
            {
                throw new KeyNotFoundException("GradeCourse non trouvé avec l'ID spécifié.");
            }
            if (existingGradeCourse.Id == courseGrade.Id)
            {
                var gradeCourseToUpdate = _mapper.Map<GradeCourse>(courseGrade);
                await _gradeCourseRepository.UpdateAsync(gradeCourseToUpdate);
                return true;
            }
            return false;
        }*/
    }
}
