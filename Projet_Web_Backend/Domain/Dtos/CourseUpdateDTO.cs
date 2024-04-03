using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;
    public class CourseUpdateDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }