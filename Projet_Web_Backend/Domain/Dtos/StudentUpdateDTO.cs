using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class StudentUpdateDTO
{
    public int StudentId { get; set; }
    public string? StudentUsername { get; set; }
}