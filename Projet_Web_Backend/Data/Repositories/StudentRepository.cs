using Data.Data;
using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly BackendContext _context;

    public StudentRepository(BackendContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<ICollection<Student>> GetStudents()
    {
        return await _context.Students.OrderBy(s => s.StudentId).ToListAsync();
    }
    public async Task<Student> GetStudent(int studentId)
    {
        return await _context.Students.Where(s => s.StudentId == studentId).FirstOrDefaultAsync();
    }
    public async Task<Student> AddStudent(Student student)
    {
        var result = await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<Student> UpdateStudent(Student student)
    {
        var result = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == student.StudentId);
        if (result != null)
        {
            result.StudentUsername = student.StudentUsername;
            await _context.SaveChangesAsync();
            return result;
        }
        return null;
    }
    public async Task<Student> GetStudentByUsername(string userName)
    {
        return _context.Students.Where(s => s.StudentUsername == userName).FirstOrDefault();
    }
    public async Task<IEnumerable<Course>> GetCoursesByStudent(int studentId)
    {
        var studentWithCourses = await _context.Students.
            Where(s => s.StudentId == studentId)
            .SelectMany(s => s.Courses)
            .ToListAsync();
        return studentWithCourses;
    }
    public void DeleteStudent(Student student)
    {
        _context.Students.Remove(student);
        _context.SaveChanges();
    }
    public bool StudentExists(int studentId)
    {
        return _context.Students.Any(s => s.StudentId == studentId);
    }
}