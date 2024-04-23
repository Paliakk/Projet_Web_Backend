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
    public class AssignementRepository : IAssignementRepository
    {
        private readonly AuthDbContext _context;
        public AssignementRepository(AuthDbContext context)
        {
            _context = context;
        }
        public async Task<Assignment> AddAsync(Assignment assignement)
        {
            //Ajouter un assignment
            var result = await _context.Assignment.AddAsync(assignement);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Assignment?> DeleteAsync(int assignementId)
        {
            var existingAssignement = await _context.Assignment.FirstOrDefaultAsync(c => c.Id == assignementId);
            if (existingAssignement is null)
            {
                return null;
            }
            _context.Assignment.Remove(existingAssignement);
            await _context.SaveChangesAsync();
            return existingAssignement;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            var assignements = await _context.Assignment.ToListAsync();
            return assignements;
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _context.Assignment.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId)
        {
            return await _context.Assignment.Where(c => c.CourseId == courseId).ToListAsync();
        }

        public async Task<Assignment?> SearchByTitleAsync(string title)
        {
            return await _context.Assignment.FirstOrDefaultAsync(c => c.Title == title);
        }

        public async Task UpdateAsync(Assignment assignement)
        {
            var existingAssignement = await _context.Assignment.FirstOrDefaultAsync(c => c.Id == assignement.Id);
            if (existingAssignement != null)
            {
                _context.Entry(existingAssignement).CurrentValues.SetValues(assignement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
