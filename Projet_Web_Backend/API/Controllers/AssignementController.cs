﻿using AutoMapper;
using Business.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Student,Instructor")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
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
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
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
        [HttpGet("GetAssignementsByCourseByInstructorId/{instructorId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]

        public async Task<ActionResult<AssignementReadDTO>> GetAssignementsByCourseByInstructorId(int instructorId)
        {
            try
            {
                var assignement = await _assignementService.GetAssignmentsByCourseByInstructorId(instructorId);
                return Ok(assignement);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
        [HttpGet("GetAllWithCourses")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Instructor")]
        public async Task<ActionResult<IEnumerable<AssignementReadWithCourseDTO>>> GetAllWithCourse()
        {
            try
            {
                var assignments = await _assignementService.GetAllWithCourse();
                return Ok(assignments);
            }catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
