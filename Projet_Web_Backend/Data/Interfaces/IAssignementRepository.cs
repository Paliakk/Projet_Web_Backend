using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAssignementRepository
    {
        Task<Assignment> GetByIdAsync(int id);
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId);
        Task<Assignment?> SearchByTitleAsync(string title);
        Task<Assignment> AddAsync(Assignment assignement);
        Task UpdateAsync(Assignment assignement);
        Task<Assignment?> DeleteAsync(int assignementId);
    }
}
