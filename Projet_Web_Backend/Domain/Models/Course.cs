using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Course{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter a course name")]
    [StringLength(100, ErrorMessage = "The course name is too long", MinimumLength = 3)]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Please enter a course description")]
    [StringLength(500, ErrorMessage = "The course description is too long", MinimumLength = 3)]
    public string? Description { get; set; }

}