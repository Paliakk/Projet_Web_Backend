using Business.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAssignmentController : Controller
    {
        private readonly IStudentAssignmentService _studentAssignmentService;
        public StudentAssignmentController(IStudentAssignmentService studentAssignmentService)
        {
            _studentAssignmentService = studentAssignmentService;
        }
        [HttpGet("GetAllStudentAssignments")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> GetAllStudentAssignments()
        {
            var studentAssignments = await _studentAssignmentService.GetAllAsync();
            return Ok(studentAssignments);
        }
        [HttpGet("GetStudentAssignmentsByAssignmentId/{assignmentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> GetStudentAssignmentsByAssignmentId(int assignmentId)
        {
            var studentAssignments = await _studentAssignmentService.GetByAssignmentIdAsync(assignmentId);
            return Ok(studentAssignments);
        }
        [HttpGet("GetStudentAssignmentsByStudentId/{studentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> GetStudentAssignmentsByStudentId(int studentId)
        {
            var studentAssignments = await _studentAssignmentService.GetByStudentIdAsync(studentId);
            return Ok(studentAssignments);
        }
        [HttpGet("GetStudentAssignmentById/{studentAssignmentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> GetStudentAssignmentById(int studentAssignmentId)
        {
            var studentAssignment = await _studentAssignmentService.GetByIdAsync(studentAssignmentId);
            return Ok(studentAssignment);
        }
        [HttpPost("AddStudentAssignment/{studentId}/{assignmentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<IActionResult> AddStudentAssignment(int studentId, int assignmentId)
        {
            var result = await _studentAssignmentService.AddAsync(studentId,assignmentId);
            return Ok(result);
        }
        [HttpPut("UpdateStudentAssignmentGrade")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<IActionResult> UpdateStudentAssignmentGrade([FromBody] StudentAssignmentGradeDTO studentAssignment)
        {
            var result = await _studentAssignmentService.AddGradeAsync(studentAssignment);
            return Ok(result);
        }
        [HttpPut("UpdateStudentAssignment")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<IActionResult> UpdateStudentAssignment([FromBody] StudentAssignmentUpdateDTO studentAssignment)
        {
            var result = await _studentAssignmentService.UpdateAsync(studentAssignment);
            return Ok(result);
        }
        [HttpPost("SubmitStudentAssignment/{studentAssignmentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> SubmitStudentAssignment(int studentAssignmentId,string filePath)
        {
            var result = await _studentAssignmentService.SubmitAssignment(studentAssignmentId,filePath);
            return Ok(result);
        }
        [HttpDelete("DeleteStudentAssignment/{studentAssignmentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<IActionResult> DeleteStudentAssignment(int studentAssignmentId)
        {
            var result = await _studentAssignmentService.DeleteAsync(studentAssignmentId);
            return Ok(result);
        }
        [HttpGet("GetAllStudentAssignmentsWithCourseName/{studentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> GetAllStudentAssignmentsWithCourseName(int studentId)
        {
            var studentAssignments = await _studentAssignmentService.GetAllWithCourseNameAsync( studentId);
            return Ok(studentAssignments);
        }
        [HttpGet("GetDetailedAssignmentsByStudentId/{studentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> GetDetailedAssignmentsByStudentId(int studentId)
        {
            var studentAssignments = await _studentAssignmentService.GetDetailedAssignmentsByStudentId(studentId);
            return Ok(studentAssignments);
        }
        [HttpPut("LateAssignment/{studentAssignmentId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
        public async Task<IActionResult> LateAssignment(int studentAssignmentId)
        {
            var result = await _studentAssignmentService.LateAssignment(studentAssignmentId);
            return Ok(result);
        }
        [HttpGet("GetAverageGradeByStudentId/{studentId}")]
        public async Task<IActionResult> GetAverageGradeByStudentId(int studentId)
        {
            var result = await _studentAssignmentService.GetAverageGradeByStudentId(studentId);
            return Ok(result);
        }
        [HttpGet("GetAverageGradeByStudentByCourseId/{studentId}/{courseId}")]
        public async Task<IActionResult> GetAverageGradeByStudentByCourseId(int studentId,int courseId)
        {
            var result = await _studentAssignmentService.GetAverageGradeByStudentByCourseId(studentId,courseId);
            return Ok(result);
        }
    }
}
