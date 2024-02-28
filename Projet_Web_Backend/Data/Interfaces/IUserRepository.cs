using Domain.Dtos;
using Domain.Models;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        Task<LoginResponsetDTO> Login(LoginRequestDTO loginResuestDTO);
        Task<LocalUser> Register(RegistrationRequestDTO registrationRequestDTO);
    }
}
