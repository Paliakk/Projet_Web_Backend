using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;
    public class CourseCreateDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
    }