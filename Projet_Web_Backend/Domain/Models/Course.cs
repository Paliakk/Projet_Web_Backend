using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Course{
    public int CourseId { get; set; }
    [Required(ErrorMessage = "Please enter a course name")]
    [StringLength(100, ErrorMessage = "The course name is too long", MinimumLength = 3)]
    public string? CourseName { get; set; }
    [Required(ErrorMessage = "Please enter a course description")]
    [StringLength(500, ErrorMessage = "The course description is too long", MinimumLength = 3)]
    public string? CourseDescription { get; set; }
    
    public  ICollection<Student>? Students { get; set; }
    public  ICollection<Instructor>? Instructors { get; set; }

}