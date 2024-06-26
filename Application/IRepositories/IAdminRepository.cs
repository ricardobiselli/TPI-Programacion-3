using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Application.IRepositories
{
    public interface IAdminRepository
    {
        Task AddAsync(Admin admin);
        Task<IEnumerable<Admin>> GetAllAsync();
        Task<Admin> GetByIdAsync(int id);
        Task UpdateAsync(Admin admin);
        Task DeleteAsync(int id);
    }
}
