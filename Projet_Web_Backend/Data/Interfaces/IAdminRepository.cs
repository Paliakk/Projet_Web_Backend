using Domain.Models;

namespace Data.Interfaces;

public interface IAdminRepository
{
    Task<IEnumerable<Admin>> GetAdmins();
    Task<Admin> GetAdmin(int adminId);
    Task<Admin> AddAdmin(Admin admin);
    Task<Admin> UpdateAdmin(Admin admin);
    Task<Admin> GetAdminByName(string name);
    void DeleteAdmin(Admin admin);
}
