using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter a username")]
        [StringLength(100, ErrorMessage = "The username is too long", MinimumLength = 3)]
        public string? StudentUsername { get; set; }
        public  ICollection<Course>? Courses { get; set; }
    }
}