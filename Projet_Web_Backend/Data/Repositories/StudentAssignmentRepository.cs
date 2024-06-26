﻿using Data.Interfaces;
using Domain.Dtos;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class StudentAssignmentRepository : IStudentAssignmentRepository
    {
        private readonly AuthDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        public StudentAssignmentRepository(AuthDbContext context, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AddAsync(int studentId, int assignmentId)
        {
            var user = await _context.Users.FindAsync(studentId);
            if(user == null || user.UserName ==null)
            {
                throw new KeyNotFoundException("Utilisateur non trouvé avec l'ID spécifié.");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Student"))
            {
                throw new UnauthorizedAccessException("Seuls les étudiants peuvent être ajoutés à un devoir.");
            }
            var assignment = await _context.Assignment.FindAsync(assignmentId);
            if (assignment == null || assignment.Title == null)
            {
                throw new KeyNotFoundException("Devoir non trouvé avec l'ID spécifié.");
            }

            bool isStudentAlreadyAssigned = await _context.StudentAssignment.AnyAsync(sa => sa.StudentId == studentId && sa.AssignmentId == assignmentId);
            if (isStudentAlreadyAssigned)
            {
                throw new InvalidOperationException("L'étudiant est déjà assigné à ce devoir.");
            }
            var studentAssignment = new StudentAssignment
            {
                StudentId = studentId,
                AssignmentId = assignmentId,
                Status = "Active"
            };
            await _context.StudentAssignment.AddAsync(studentAssignment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddGradeAsync(int studentAssignmentId, decimal grade)
        {
            var existingStudentAssignment = await _context.StudentAssignment.FirstOrDefaultAsync(sa => sa.Id == studentAssignmentId);
            if (existingStudentAssignment == null)
            {
                throw new KeyNotFoundException("Devoir de l'étudiant non trouvé avec l'ID spécifié.");
            }
            existingStudentAssignment.Grade = grade;
            existingStudentAssignment.Status = "Completed";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SubmitAssignment(int studentAssignmentId, string filePath)
        {
            var existingStudentAssignment = await _context.StudentAssignment.FirstOrDefaultAsync(sa => sa.Id == studentAssignmentId);
            if (existingStudentAssignment == null)
            {
                throw new KeyNotFoundException("Devoir de l'étudiant non trouvé avec l'ID spécifié.");
            }
            if(existingStudentAssignment.Status == "Completed" || existingStudentAssignment.Status == "Submitted")
            {
                return false;
            }
            if(existingStudentAssignment.Status == "Late")
            {
                existingStudentAssignment.FilePath = filePath;
                existingStudentAssignment.Status = "Late";
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                existingStudentAssignment.FilePath = filePath;
                existingStudentAssignment.Status = "Submitted";
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> LateAssignment(int studentAssignmentId)
        {
            var existingStudentAssignment = await _context.StudentAssignment.FirstOrDefaultAsync(sa => sa.Id == studentAssignmentId);
            if(existingStudentAssignment == null)
            {
                throw new KeyNotFoundException("Devoir de l'étudiant non trouvé avec l'ID spécifié.");
            }
            if(existingStudentAssignment.FilePath == null)
            {
                existingStudentAssignment.Grade = 0;
                existingStudentAssignment.Status = "Late";
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingStudentAssignment = await _context.StudentAssignment.FirstOrDefaultAsync(sa => sa.Id == id);
            if (existingStudentAssignment is null)
            {
                return false;
            }
            _context.StudentAssignment.Remove(existingStudentAssignment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StudentAssignment>> GetAllAsync()
        {
            var studentAssignments = await _context.StudentAssignment.ToListAsync();
            return studentAssignments;
        }

        public async Task<IEnumerable<StudentAssignment>> GetByAssignmentIdAsync(int assignmentId)
        {
            var studentAssignment = await _context.StudentAssignment
                .Where(gc => gc.Assignment != null && gc.Assignment.Id == assignmentId)
                .ToListAsync();
            return studentAssignment;
        }

        public async Task<StudentAssignment> GetByIdAsync(int id)
        {
            var result = await _context.StudentAssignment.FirstOrDefaultAsync(sa => sa.Id == id);
            return result;
        }

        public async Task<IEnumerable<StudentAssignment>> GetByStudentIdAsync(int studentId)
        {
            var result = await _context.StudentAssignment
                .Where(sa => sa.Student != null && sa.Student.Id == studentId)
                .ToListAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(StudentAssignment studentAssignment)
        {
            var existingStudentAssignment = await _context.StudentAssignment.FirstOrDefaultAsync(sa => sa.Id == studentAssignment.Id);
            if (existingStudentAssignment != null)
            {
                _context.Entry(existingStudentAssignment).CurrentValues.SetValues(studentAssignment);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<decimal> GetAverageGradeByStudentId(int studentId)
        {
            decimal totalGrade = _context.StudentAssignment.Where(StudentAssignment => StudentAssignment.StudentId == studentId && StudentAssignment.Grade != null)
                .Sum(StudentAssignment => StudentAssignment.Grade ?? 0);
            int totalAssignments = _context.StudentAssignment.Where(StudentAssignment => StudentAssignment.StudentId == studentId && StudentAssignment.Grade != null).Count();
            decimal avg = 0;
            if (totalAssignments != 0)
            {
                avg = (decimal)totalGrade / totalAssignments;
            }
            if(avg == 0)
            {
                return 0;
            }
            return avg;
        }
        public async Task<decimal> GetAverageGradeByStudentByCourseId(int studentId, int courseId)
        {
            decimal totalGrade = _context.StudentAssignment.Where(StudentAssignment => StudentAssignment.StudentId == studentId && StudentAssignment.Grade != null && StudentAssignment.Assignment.CourseId == courseId)
                .Sum(StudentAssignment => StudentAssignment.Grade ?? 0);
            int totalAssignments = _context.StudentAssignment.Where(StudentAssignment => StudentAssignment.StudentId == studentId && StudentAssignment.Grade != null && StudentAssignment.Assignment.CourseId == courseId).Count();
            decimal avg = 0;
            if (totalAssignments != 0)
            {
                avg = (decimal)totalGrade / totalAssignments;
            }
            if (avg == 0)
            {
                return 0;
            }
            return avg;
        }
        public async Task<IEnumerable<StudentAssignment>> GetSubmittedAssignments(int courseId)
        {
            var studentAssignments = await _context.StudentAssignment
                .Include(sa => sa.Assignment)
                .ThenInclude(a => a.Course)
                .Where(sa => sa.Assignment.CourseId == courseId && sa.Status == "Submitted")
                .ToListAsync();

            return studentAssignments;
        }
        public async Task<IEnumerable<StudentAssignment>> GetGradedAssignments(int courseId)
        {
            var studentAssignments = await _context.StudentAssignment
                .Include(sa => sa.Assignment)
                .ThenInclude(a => a.Course)
                .Where(sa => sa.Assignment.CourseId == courseId && sa.Status == "Completed")
                .ToListAsync();

            return studentAssignments;
        }
        public async Task<IEnumerable<StudentAssignment>> GetLateAssignments(int courseId)
        {
            var studentAssignments = await _context.StudentAssignment
                .Include(sa => sa.Assignment)
                .ThenInclude(a => a.Course)
                .Where(sa => sa.Assignment.CourseId == courseId && sa.Status == "Late")
                .ToListAsync();

            return studentAssignments;
        }
    }
}
