using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;
public class CourseDTO
{
    public int CourseId { get; set; }
    [Required]
    public string? CourseName { get; set; }
    [Required]
    public string? CourseDescription { get; set; }
}