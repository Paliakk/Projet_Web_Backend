﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        public AuthDbContext()
        {
        }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseStudent> CourseStudent { get; set; }
        public DbSet<CourseInstructor> CourseInstructor { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<StudentAssignment> StudentAssignment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var studentRoleId = 1;
            var adminRoleId = 2;
            var instructorRoleId = 3;

            // Create Admin, Instructor and Student Role
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole()
                {
                    Id = studentRoleId,
                    Name = "Student",
                    NormalizedName = "Student".ToUpper()
                },
                new ApplicationRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName="Admin".ToUpper()
                },
                new ApplicationRole()
                {
                    Id = instructorRoleId,
                    Name = "Instructor",
                    NormalizedName = "Instructor".ToUpper()
                }
            };

            // Seed roles

            builder.Entity<ApplicationRole>().HasData(roles);

            // Create Admin User
            var adminUserId = 1;
            var admin = new ApplicationUser()
            {
                Id = adminUserId,
                UserName = "admin",
                Email = "admin@ephec.be",
                NormalizedEmail = "admin@ephec.be".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            admin.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(admin, "Admin123");

            builder.Entity<ApplicationUser>().HasData(admin);

            //Give Roles to Admin
            var adminRoles = new List<IdentityUserRole<int>>()
            {
                 new()
                 {
                     UserId = adminUserId,
                     RoleId = adminRoleId,
                 }
            };

            builder.Entity<IdentityUserRole<int>>().HasData(adminRoles);

        }
    }
}
