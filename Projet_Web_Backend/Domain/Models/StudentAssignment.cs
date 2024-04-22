using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudentAssignment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        [Range(0, 20, ErrorMessage = "La valeur doit être comprise entre 0 et 20")]
        public int? Grade { get; set; }
    }
}
