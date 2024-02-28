using Domain.Models;

namespace Domain.Dtos
{
    public class LoginResponsetDTO
    {
        public LocalUser? User { get; set; }
        public string? Token { get; set; }
    }
}