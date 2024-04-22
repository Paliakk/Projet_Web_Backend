using Business.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseGradeController : Controller
    {
        private readonly ICourseGradeService _courseGradeService;

        public CourseGradeController(ICourseGradeService courseGradeService)
        {
            _courseGradeService = courseGradeService;
        }
        /*[HttpGet("GetAllGrades")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseGradeService.GetAllAsync();
            return Ok(courses);
        }
        [HttpGet("GetGradesByCourseId/{courseId}")]
        /*public async Task<IActionResult> GetGradesByCourseId(int courseId)
        {
            var courses = await _courseGradeService.GetByCourseIdAsync(courseId);
            return Ok(courses);
        }
        [HttpGet("GetGradesByAssignmentId/{assignmentId}")]
        public async Task<IActionResult> GetGradesByAssignmentId(int assignmentId)
        {
            var courses = await _courseGradeService.GetByAssignmentIdAsync(assignmentId);
            return Ok(courses);
        }
        [HttpPost("AddGrade")]
        public async Task<IActionResult> AddGrade([FromBody] GradeCourseCreateDto gradeCourse)
        {
            var result = await _courseGradeService.AddAsync(gradeCourse);
            return Ok(result);
        }
        [HttpPut("UpdateGrade")]
        public async Task<IActionResult> UpdateGrade([FromBody] GradeCourseUpdateDto gradeCourse)
        {
            var result = await _courseGradeService.UpdateAsync(gradeCourse);
            return Ok(result);
        }
        [HttpDelete("DeleteGrade/{gradeCourseId}")]
        public async Task<IActionResult> DeleteGrade(int gradeCourseId)
        {
            var result = await _courseGradeService.DeleteAsync(gradeCourseId);
            return Ok(result);
        }*/
    }
}
