using Data.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GradeCourseRepository : IGradeCourseRepository
    {
        /*private readonly AuthDbContext _context;
        public GradeCourseRepository(AuthDbContext context)
        {
            _context = context;
        }
        public async Task<GradeCourse> AddAsync(GradeCourse gradeCourse)
        {
            var result = await _context.GradeCourse.AddAsync(gradeCourse);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<GradeCourse> DeleteAsync(int gradeCourseId)
        {
            var existingGradeCourse = await _context.GradeCourse.FirstOrDefaultAsync(c => c.Id == gradeCourseId);
            if (existingGradeCourse is null)
            {
                return null;
            }
            _context.GradeCourse.Remove(existingGradeCourse);
            await _context.SaveChangesAsync();
            return existingGradeCourse;
        }

        public async Task<IEnumerable<GradeCourse>> GetAllAsync()
        {
            var gradeCourses = await _context.GradeCourse.ToListAsync();
            return gradeCourses;
        }

        public async Task<IEnumerable<GradeCourse>> GetByAssignmentIdAsync(int assignmentId)
        {
            var gradeCourses = await _context.GradeCourse
                .Where(gc => gc.Assignment != null && gc.Assignment.Id == assignmentId)
                .ToListAsync();
            return gradeCourses;
        }

        public async Task<IEnumerable<GradeCourse>> GetByCourseIdAsync(int courseId)
        {
            var gradeCourses = await _context.GradeCourse
                .Include(gc=> gc.Assignment)
                .Where(gc => gc.Assignment != null && gc.Assignment.CourseId == courseId)
                .ToListAsync();
            return gradeCourses;
        }

        public async Task<GradeCourse> GetByIdAsync(int gradeCourseId)
        {
            var gradeCourse = await _context.GradeCourse.FirstOrDefaultAsync(c => c.Id == gradeCourseId);
            return gradeCourse;
        }

        public async Task<IEnumerable<GradeCourse>> GetByStudentIdAsync(int studentId)
        {
            var gradeCourses = await _context.GradeCourse
                .Where(gc => gc.StudentId == studentId)
                .ToListAsync();
            return gradeCourses;
        }

        public async Task UpdateAsync(GradeCourse gradeCourse)
        {
            var existingGradeCourse = await _context.GradeCourse.FirstOrDefaultAsync(c => c.Id == gradeCourse.Id);
            if (existingGradeCourse != null)
            {
                _context.Entry(existingGradeCourse).CurrentValues.SetValues(gradeCourse);
                await _context.SaveChangesAsync();
            }
        }*/
    }
}
