using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class InstructorDTO
{

    [Required(ErrorMessage = "Please enter a username")]
    [StringLength(100, ErrorMessage = "The username is too long", MinimumLength = 3)]
    public string? InstructorUsername { get; set; }
}