using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AutoMapper;
using Domain.Dtos;
using Data.Interfaces;
using Domain.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;


    public StudentController(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDTO>>> Getstudents()
    {
        try
        {
            IEnumerable<Student> students = await _studentRepository.GetStudents();
            return Ok(_mapper.Map<IEnumerable<StudentDTO>>(students));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
    [HttpPost]
    public async Task<ActionResult<StudentCreateDTO>> CreateStudent([FromBody] StudentCreateDTO createDTO)
    {
        try
        {
            if (createDTO == null)
            {
                return BadRequest(createDTO);
            }
            Student model = _mapper.Map<Student>(createDTO);
            await _studentRepository.AddStudent(model);
            if (model == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding the student");
            }
            return Created("", model);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
    [HttpGet("{studentId}")]
    public async Task<ActionResult<StudentDTO>> GetStudent(int studentId)
    {
        try
        {
            var student = await _studentRepository.GetStudent(studentId);
            if (student == null)
            {
                return NotFound("The student record couldn't be found");
            }
            return Ok(_mapper.Map<StudentDTO>(student));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }
    [HttpPut("{studentId}")]
    public async Task<ActionResult> UpdateStudent(int studentId, [FromBody] StudentUpdateDTO updateDTO)
    {
        try
        {
            if (studentId != updateDTO.StudentId)
            {
                return BadRequest("Student ID mismatch");
            }
            var studentToUpdate = await _studentRepository.GetStudent(studentId);
            if (studentToUpdate == null)
            {
                return NotFound("The student record couldn't be found");
            }
            Student model = _mapper.Map(updateDTO, studentToUpdate);
            return Ok(await _studentRepository.UpdateStudent(model));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
        }
    }
    [HttpDelete("{studentId}")]
    public async Task<ActionResult<Student>> DeleteStudent(int studentId)
    {
        try
        {
            var studentToDelete = await _studentRepository.GetStudent(studentId);
            if (studentToDelete == null)
            {
                return NotFound("The student record couldn't be found");
            }
            _studentRepository.DeleteStudent(studentToDelete);
            return Ok("Student record deleted");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
        }
    }
    [HttpGet("{studentId}/courses")]
    public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCoursesByStudent(int studentId)
    {
        try
        {
            IEnumerable<Course> courses = await _studentRepository.GetCoursesByStudent(studentId);
            if (courses == null)
            {
                return NotFound("The student record couldn't be found");
            }
            return Ok(_mapper.Map<IEnumerable<CourseDTO>>(courses));
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
        }
    }

}