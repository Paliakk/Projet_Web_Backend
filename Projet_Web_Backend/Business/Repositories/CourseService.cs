using AutoMapper;
using Business.Interfaces;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        IMapper _mapper;
        public CourseService(ICourseRepository courseRepo,IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _courseRepository = courseRepo;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCourses();
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
        public async Task<CourseDTO?> GetCourseById(int courseId)
        {
            var course = await _courseRepository.GetCourseById(courseId);
            return _mapper.Map<CourseDTO?>(course);
        }
        public async Task<Course> AddCourse(CourseCreateDTO createDTO)
        {
            var courseToAdd = _mapper.Map<Course>(createDTO);
            var addedCourse = await _courseRepository.AddCourse(courseToAdd);
            return _mapper.Map<Course>(addedCourse);
        }
        public async Task UpdateCourse(CourseDTO course)
        {
            var existingCourse = await _courseRepository.GetCourseById(course.Id);
            if(existingCourse == null)
            {
                throw new KeyNotFoundException("Cours non trouvé avec l'ID spécifié.");
            }
            if(existingCourse.Id == course.Id)
            {
                var courseToUpdate = _mapper.Map<Course>(course);
                await _courseRepository.UpdateCourse(courseToUpdate);
            }
        }
        public async Task<CourseDTO> DeleteCourse(int courseId)
        {
            var course = await _courseRepository.DeleteCourse(courseId);
            if (course == null)
            {
                return null;
            }

            return _mapper.Map<CourseDTO>(course);
        }
        // Utilisation de DTO inutile
        public async Task<bool> AddStudentToCourse(int studentId, int courseId)
        {
            return await _courseRepository.AddStudentToCourse(studentId, courseId);
        }
        public async Task<bool> AddInstructorToCourse(int instructorId, int courseId)
        {
            return await _courseRepository.AddInstructorToCourse(instructorId, courseId);
        }
        public async Task<bool> RemoveStudentFromCourse(int studentId, int courseId)
        {
            return await _courseRepository.RemoveStudentFromCourse(studentId, courseId);
        }
        public async Task<IEnumerable<UserDTO>> GetStudentsByCourse(int courseId)
        {
            var users = await _courseRepository.GetStudentsByCourse(courseId);
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
        public async Task<IEnumerable<CourseDTO>> GetCoursesByStudentId(int studentId)
        {
            var courses = await _courseRepository.GetCoursesByStudentId(studentId);
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
        public async Task<IEnumerable<CourseDTO>> GetCoursesByInstructorName(string instructorName)
        {
            var courses = await _courseRepository.GetCoursesByInstructorName(instructorName);
            return _mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
        public async Task<bool> UpdateCourseInstructor(int courseId, string instructorName)
        {
            return await _courseRepository.UpdateCourseInstructor(courseId, instructorName);
        }
        public async Task<bool> RemoveAllStudentsFromCourse(int courseId)
        {
            return await _courseRepository.RemoveAllStudentsFromCourse(courseId);
        }
    }
}
