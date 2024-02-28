using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;



namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorController : ControllerBase
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly IMapper _mapper;

    public InstructorController(IInstructorRepository instructorRepository,IMapper mapper)
    {
        _instructorRepository = instructorRepository;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InstructorDTO>>> GetInstructors()
    {
        try
        {
            IEnumerable<Instructor> instructors = await _instructorRepository.GetInstructors();
            return Ok(_mapper.Map<IEnumerable<InstructorDTO>>(instructors));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
    [HttpPost]
    public async Task<ActionResult<InstructorCreateDTO>> AddInstructor([FromBody]InstructorCreateDTO createDTO)
    {
        try
        {
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Instructor model = _mapper.Map<Instructor>(createDTO);
            await _instructorRepository.AddInstructor(model);
            if (createDTO == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding the instructor");
            }
            return Created("", model);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
    [HttpGet("{instructorId}")]
    public async Task<ActionResult<InstructorDTO>> GetInstructor(int instructorId)
    {
        try
        {
            var result = await _instructorRepository.GetInstructor(instructorId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<InstructorDTO>(result));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
    [HttpPut("{instructorId}")]
    public async Task<ActionResult<InstructorUpdateDTO>> UpdateInstructor(int instructorId, [FromBody]InstructorUpdateDTO updateDTO)
    {
        try
        {
            if (instructorId != updateDTO.InstructorId)
            {
                return BadRequest("Instructor Id mismatch");
            }
            var instructorToUpdate = await _instructorRepository.GetInstructor(instructorId);
            InstructorUpdateDTO instructorDTO = _mapper.Map<InstructorUpdateDTO>(instructorToUpdate);
            if (instructorToUpdate == null)
            {
                return NotFound("The instructor record couldn't be found");
            }
            Instructor model = _mapper.Map<Instructor>(updateDTO);
            return Ok(await _instructorRepository.UpdateInstructor(model));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
        }
    }
    [HttpDelete("{instructorId}")]
    public async Task<ActionResult<Instructor>> DeleteInstructor(int instructorId)
    {
        try
        {
            var instructorToDelete = await _instructorRepository.GetInstructor(instructorId);
            if (instructorToDelete == null)
            {
                return NotFound("The instructor record couldn't be found");
            }
            _instructorRepository.DeleteInstructor(instructorToDelete);
            return instructorToDelete;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
        }
    }
}
