using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;
    public class CourseUpdateDTO
    {
        [Required]
        public string? CourseName { get; set; }
        [Required]
        public string? CourseDescription { get; set; }
    }