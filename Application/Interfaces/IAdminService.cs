using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        Task AddAsync(Admin admin);
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(int id);
        Task UpdateAsync(int id, Admin updatedAdmin);
        Task DeleteAsync(int id);
    }
}