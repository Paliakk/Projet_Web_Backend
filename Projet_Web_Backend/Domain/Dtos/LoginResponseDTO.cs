using Domain.Models;

namespace Domain.Dtos
{
    public class LoginResponsetDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public List<string> Roles { get; set; }
    }
}