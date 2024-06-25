using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Users;
using Application.Interfaces;
using Application.IRepositories;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task AddAsync(Admin admin)
        {
            await _adminRepository.AddAsync(admin);
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            return await _adminRepository.GetAllAsync();
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            return await _adminRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(int id, Admin updatedAdmin)
        {
            var admin = await _adminRepository.GetByIdAsync(id);
            if (admin != null)
            {
                admin.UserName = updatedAdmin.UserName;
                admin.Email = updatedAdmin.Email;
                admin.Password = updatedAdmin.Password;

                await _adminRepository.UpdateAsync(admin);
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _adminRepository.DeleteAsync(id);
        }
    }
}
