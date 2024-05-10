using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class LoginRequestDTO
    {
        public string? Login { get; set; }
        public string? Password { get; set; }
    }
}