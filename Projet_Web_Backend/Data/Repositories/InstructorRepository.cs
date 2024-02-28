using Data.Data;
using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class InstructorRepository : IInstructorRepository
{
    private readonly BackendContext _context;

    public InstructorRepository(BackendContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<IEnumerable<Instructor>> GetInstructors()
    {
        return await _context.Instructors.OrderBy(i => i.InstructorId).ToListAsync();
    }
    public async Task<Instructor> GetInstructor(int instructorId)
    {
        return await _context.Instructors.Where(i => i.InstructorId == instructorId).FirstOrDefaultAsync();
    }
    public async Task<Instructor> AddInstructor(Instructor instructor)
    {
        var result = await _context.Instructors.AddAsync(instructor);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<Instructor> UpdateInstructor(Instructor instructor)
    {
        var result = await _context.Instructors.FirstOrDefaultAsync(i => i.InstructorId == instructor.InstructorId);
        if (result != null)
        {
            result.InstructorUsername = instructor.InstructorUsername;
            await _context.SaveChangesAsync();
            return result;
        }
        return null;
    }
    public async Task<Instructor> GetInstructorByUsername(string userName)
    {
        return _context.Instructors.Where(i => i.InstructorUsername == userName).FirstOrDefault();
    }
    public IEnumerable<Course> GetCoursesByInstructor(int instructorId)
    {
        throw new NotImplementedException();
    }
    public void DeleteInstructor(Instructor instructor)
    {
        _context.Instructors.Remove(instructor);
        _context.SaveChanges();
    }
}