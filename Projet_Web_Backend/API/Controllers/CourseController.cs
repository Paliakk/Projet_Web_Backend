using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Domain.Dtos;
using Data.Interfaces;
using Domain.Models;
using Business.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        #region Cours
        // GET: http://localhost:5137/api/Course
        [HttpGet("GetAllCourses")]
        [Authorize(AuthenticationSchemes = "Bearer",Roles ="Admin,Student,Instructor")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            try
            {
                var courses = await _courseService.GetAllCourses();
                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }

        // GET: http://localhost:5137/api/Course/{courseId}
        [HttpGet("GetCourseById/{courseIdDTO}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]

        public async Task<ActionResult<CourseDTO>> GetCourseById([FromRoute]int courseIdDTO)
        {
            try
            {
                var course = await _courseService.GetCourseById(courseIdDTO);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        // return CreatedAtAction(nameof(GetCourse), new { id = createdCourse.CourseId }, createdCourse); C'est la ligne de code que j'avais précédemment pour la création d'un cours
        // Mais je l'ai remplacé par la ligne de code suivante car elle posait des soucis 
        // POST: http://localhost:5137/api/Course
        [HttpPost("CreateCourse")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult<CourseCreateDTO>> CreateCourse([FromBody] CourseCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                await _courseService.AddCourse(createDTO);
                return Created("", createDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding the course");
            }

        }

        // PUT: http://localhost:5137/api/Course/{courseId}
        [HttpPut("UpdateCourse/{courseId}")]

        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> UpdateCourse([FromRoute]int courseId,[FromBody] CourseUpdateDTO updateDTO)
        {
            try
            {
                var existingCourse = await _courseService.GetCourseById(courseId);
                if (existingCourse == null)
                {
                    return NotFound($"Cours non trouvé avec l'ID {courseId}.");
                }
                var courseDTO = _mapper.Map<CourseDTO>(updateDTO);
                _mapper.Map(updateDTO, courseDTO);
                courseDTO.Id = courseId; // S'assurer que l'ID est correct
                await _courseService.UpdateCourse(courseDTO);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating course record");
            }
        }

        // DELETE: http://localhost:5137/api/Course/{courseId}
        [HttpDelete("DeleteCourse/{courseId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        //[Authorize(Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteCourse([FromRoute]int courseId)
        {
            try
            {
                var courseDTO = await _courseService.DeleteCourse(courseId);

                if (courseDTO == null)
                {
                    return NotFound($"Cours avec l'ID {courseId} non trouvé.");
                }

                // Inutile de mapper de nouveau le DTO en entité puis en DTO.
                return Ok(courseDTO);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting course record");
            }
        }
        #endregion Cours
        #region Students
        [HttpGet("GetStudentsByCourse/{courseId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetStudentsByCourse(int courseId)
        {
            try
            {
                IEnumerable<UserDTO> students = await _courseService.GetStudentsByCourse(courseId);
                if (students == null)
                {
                    return NotFound("No students found for this course");
                }
                if (!students.Any())
                {
                    return NotFound("No students found for this course");
                }
                return Ok(students);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("GetInstructorsByCourse/{courseId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetInstructorBycourse(int courseId)
        {
            try
            {
                var instructors = await _courseService.GetInstructorBycourse(courseId);

                // La vérification de la liste nulle n'est plus nécessaire ici car vous allez retourner une liste vide si aucun instructeur n'est trouvé.
                // Retourner directement les instructeurs (qui sera une liste vide si aucun n'est trouvé)
                return Ok(instructors ?? new List<UserDTO>());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("GetCoursesByStudent/{studentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesByStudent(int studentId)
        {
            try
            {
                IEnumerable<CourseDTO> courses = await _courseService.GetCoursesByStudentId(studentId);
                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("GetCoursesByInstructorName/{instructorName}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesByInstructorName(string instructorName)
        {
            try
            {
                IEnumerable<CourseDTO> courses = await _courseService.GetCoursesByInstructorName(instructorName);
                if (courses == null)
                {
                    return NotFound("No students found for this course");
                }
                if (!courses.Any())
                {
                    return NotFound("No students found for this course");
                }
                return Ok(courses);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("AddStudentToCourse/{courseId}/{studentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<IActionResult> AddStudentToCourse(int courseId, int studentId)
        {
            var result = await _courseService.AddStudentToCourse(studentId, courseId);
            if (!result)
            {
                return BadRequest(new { message = "Could not add student to course" });
            }

            return Ok(new {message = $"Student with Id = {studentId} added to course with Id = {courseId}" });

        }
        [HttpPost("AddInstructorToCourse/{courseId}/{instructorId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> AddInstructorToCourse(int courseId,int instructorId)
        {
            var result = await _courseService.AddInstructorToCourse(instructorId, courseId);
            if (!result)
            {
                return BadRequest("Could not add instructor to course");
            }

            return Ok(new {message = $"Instructor with Id = {instructorId} added to course with Id = {courseId}" });
        }
        [HttpDelete("RemoveStudentFromCourse/{courseId}/students/{studentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<IActionResult> RemoveStudentFromCourse(int courseId, int studentId)
        {
            var result = await _courseService.RemoveStudentFromCourse(studentId, courseId);
            if (!result)
            {
                return BadRequest(new { message = "Could not remove student from course" });
            }

            return Ok(new {message = $"Student with Id = {studentId} removed from course with Id = {courseId}" });
        }
        [HttpDelete("RemoveInstructorFromCourse/{courseId}/{instructorId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> RemoveInstructorFromCourse(int instructorId, int courseId)
        {
            var result = await _courseService.RemoveInstructorFromCourse(instructorId, courseId);
            if (!result) { return BadRequest(new {message = "Could not remove instructor from course" }); }
            return Ok(new { message = $"Instructor with Id = {instructorId} removed from course with Id = {courseId}" });
        }
        #endregion Students
        [HttpPut("UpdateCourseInstructor/{courseId}/{instructorName}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<IActionResult> UpdateCourseInstructor(int courseId, string instructorName)
        {
            try
            {
                var result = await _courseService.UpdateCourseInstructor(courseId, instructorName);
                if (!result)
                {
                    return BadRequest();

                }
                return Ok(new {message = "Instructor changed" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("RemoveAllStudentsFromCourse")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<IActionResult> RemoveAllStudentsFromCourse(int courseId)
        {
            try
            {
                var result = _courseService.RemoveAllStudentsFromCourse(courseId);
                if(await result)
                {
                    return Ok("Students removed");
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
