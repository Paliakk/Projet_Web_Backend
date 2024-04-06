using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CourseInstructor
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string username { get; set; }
        public ApplicationUser? User { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public Course? Course { get; set; }
    }
}
