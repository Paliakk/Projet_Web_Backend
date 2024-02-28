using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Instructor
{
    public int InstructorId { get; set; }
    [Required(ErrorMessage = "Please enter a username")]
    [StringLength(100, ErrorMessage = "The username is too long", MinimumLength = 3)]
    public string? InstructorUsername { get; set; }
    public ICollection<Course>? Courses { get; set; }
}