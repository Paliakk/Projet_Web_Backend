using AutoMapper;
using Business.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignementController : ControllerBase
    {
        private readonly IAssignementService _assignementService;
        private readonly IMapper _mapper;
        public AssignementController(IAssignementService assignementService, IMapper mapper)
        {
            _assignementService = assignementService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignementReadDTO>>> GetAllAssignements()
        {
            try
            {
                var assignements = await _assignementService.GetAllAsync();
                return Ok(assignements);
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("GetAssignementById/{id}")]
        public async Task<ActionResult<AssignementReadDTO>> GetAssignementById(int id)
        {
            try
            {
                var assignement = await _assignementService.GetByIdAsync(id);
                return Ok(assignement);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("GetAssignementByCourseId/{courseId}")]
        public async Task<ActionResult<IEnumerable<AssignementReadDTO>>> GetAssignementByCourseId(int courseId)
        {
            try
            {
                var assignements = await _assignementService.GetByCourseIdAsync(courseId);
                return Ok(assignements);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("SearchAssignementByTitle/{title}")]
        public async Task<ActionResult<AssignementReadDTO>> SearchAssignementByTitle(string title)
        {
            try
            {
                var assignement = await _assignementService.SearchByTitleAsync(title);
                return Ok(assignement);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpPost("CreateAssignement")]
        public async Task<ActionResult<AssignementReadDTO>> AddAssignement(AssignementCreateDTO assignement)
        {
            try
            {
                var assignementToAdd = await _assignementService.AddAsync(assignement);
                return Ok(assignementToAdd);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data to the database");
            }
        }
        [HttpPut("UpdateAssignement")]
        public async Task<ActionResult> UpdateAssignement(AssignementUpdateDTO assignement)
        {
            try
            {
                await _assignementService.UpdateAsync(assignement);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data in the database");
            }
        }
        [HttpDelete("DeleteAssignement/{id}")]
        public async Task<ActionResult<AssignementReadDTO>> DeleteAssignement(int id)
        {
            try
            {
                var assignement = await _assignementService.DeleteAsync(id);
                return Ok(assignement);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database");
            }
        }

    }
}
