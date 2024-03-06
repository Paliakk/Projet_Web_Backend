using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var studentRoleId = "student";
            var adminRoleId = "admin";
            var instructorRoleId = "instructor";

            // Create Admin, Instructor and Student Role
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = studentRoleId,
                    Name = "Student",
                    NormalizedName = "Student".ToUpper(),
                    ConcurrencyStamp = studentRoleId
                },
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName="Admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole()
                {
                    Id = instructorRoleId,
                    Name = "Instructor",
                    NormalizedName = "Instructor".ToUpper(),
                    ConcurrencyStamp = instructorRoleId
                }
            };

            // Seed roles

            builder.Entity<IdentityRole>().HasData(roles);

            // Create Admin User
            var adminUserId = "a66aac35-7d52-4c40-b683-d55b128065a0";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@ephec.be",
                Email = "admin@ephec.be",
                NormalizedEmail = "admin@ephec.be".ToUpper(),
                NormalizedUserName = "admin@ephec.be".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin123");

            builder.Entity<IdentityUser>().HasData(admin);

            //Give Roles to Admin
            var adminRoles = new List<IdentityUserRole<string>>()
             {
                 new()
                 {
                     UserId = adminUserId,
                     RoleId = adminRoleId,
                 }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);


        }
    }
}
