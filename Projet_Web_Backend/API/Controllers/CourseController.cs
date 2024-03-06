using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Domain.Dtos;
using Data.Interfaces;
using Domain.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        // GET: http://localhost:5137/api/Course
        [HttpGet]
        [Authorize(Roles ="Admin,Student")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            try
            {
                var courses = await _courseRepository.GetCourses();
                var response = _mapper.Map<IEnumerable<CourseDTO>>(courses);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: http://localhost:5137/api/Course/{courseId}
        [HttpGet]
        [Route("{courseIdDTO:int}")]

        public async Task<ActionResult<CourseDTO>> GetCourseById([FromRoute]int courseIdDTO)
        {
            try
            {
                var course = await _courseRepository.GetCourseById(courseIdDTO);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<CourseDTO>(course));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.CourseId }, createdCourse); C'est la ligne de code que j'avais précédemment pour la création d'un cours
        // Mais je l'ai remplacé par la ligne de code suivante car elle posait des soucis 
        // POST: http://localhost:5137/api/Course
        [HttpPost]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<ActionResult<CourseCreateDTO>> CreateCourse([FromBody] CourseCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                Course model = _mapper.Map<Course>(createDTO);
                await _courseRepository.AddCourse(model);
                return Created("", model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding the course");
            }

        }

        // PUT: http://localhost:5137/api/Course/{courseId}
        [HttpPut]
        [Route("{courseId:int}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> UpdateCourse([FromRoute]int courseId, CourseUpdateDTO updateDTO)
        {
            try
            {
                //Convert DTO to Domain model
                var course = _mapper.Map<Course>(updateDTO);
                course.CourseId = courseId;

                var updatedCourse = await _courseRepository.UpdateCourse(course);
                if(updatedCourse == null)
                {
                    return NoContent();
                }
                //Convert Domain model to DTO
                var response = _mapper.Map<CourseDTO>(updatedCourse);
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating course record");
            }
        }

        // DELETE: http://localhost:5137/api/Course/{courseId}
        [HttpDelete]
        [Route("{courseId:int}")]
        [Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteCourse([FromRoute]int courseId)
        {
            try
            {
                var course = await _courseRepository.DeleteCourse(courseId);
                
                if(course == null)
                {
                    return NotFound();
                }
                //Convert Domain
                var response = _mapper.Map<CourseDTO>(_mapper.Map<Course>(course));
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting course record");
            }
        }
        [HttpGet("{courseId}/students")]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudentsByCourse(int courseId)
        {
            try
            {
                IEnumerable<Student> students = await _courseRepository.GetStudentsByCourse(courseId);
                if (students == null)
                {
                    return NotFound("No students found for this course");
                }
                if (!students.Any())
                {
                    return NotFound("No students found for this course");
                }
                return Ok(_mapper.Map<IEnumerable<StudentDTO>>(students));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("{courseId}/students/{studentId}")]
        public async Task<IActionResult> AddStudentToCourse(int courseId, int studentId)
        {
            var result = await _courseRepository.AddStudentToCourse(studentId, courseId);
            if (!result)
            {
                return BadRequest("Could not add student to course");
            }

            return Ok($"Student with Id = {studentId} added to course with Id = {courseId}");

        }
        [HttpDelete("{courseId}/students/{studentId}")]
        public async Task<IActionResult> RemoveStudentFromCourse(int courseId, int studentId)
        {
            var result = await _courseRepository.RemoveStudentFromCourse(studentId, courseId);
            if (!result)
            {
                return BadRequest("Could not remove student from course");
            }

            return Ok($"Student with Id = {studentId} removed from course with Id = {courseId}");
        }
        [HttpPost("{courseId}/instructors/{instructorId}")]
        public async Task<IActionResult> AddInstructorToCourse(int courseId, int instructorId)
        {
            var result = await _courseRepository.AddInstructorToCourse(instructorId, courseId);
            if (!result)
            {
                return BadRequest("Could not add instructor to course");
            }

            return Ok($"Instructor with Id = {instructorId} added to course with Id = {courseId}");
        }
        [HttpDelete("{courseId}/instructors/{instructorId}")]
        public async Task<IActionResult> RemoveInstructorFromCourse(int courseId, int instructorId)
        {
            var result = await _courseRepository.RemoveInstructorFromCourse(instructorId, courseId);
            if (!result)
            {
                return BadRequest("Could not remove instructor from course");
            }

            return Ok($"Instructor with Id = {instructorId} removed from course with Id = {courseId}");
        }

    }
}
