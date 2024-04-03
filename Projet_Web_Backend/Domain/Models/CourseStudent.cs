using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public int UserID { get; set; } 
        public ApplicationUser? User { get; set; }
        public int CourseID { get; set; }
        public Course? Course { get; set; }
    }
}
