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
            try
            {
                await _adminRepository.AddAsync(admin);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the admin.", ex);
            }
        }

        public async Task<IEnumerable<Admin>> GetAllAsync()
        {
            try
            {
                return await _adminRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving all admins.", ex);
            }
        }

        public async Task<Admin> GetByIdAsync(int id)
        {
            try
            {
                return await _adminRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while retrieving the admin with ID {id}.", ex);
            }
        }

        public async Task UpdateAsync(int id, Admin updatedAdmin)
        {
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the admin with ID {id}.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var admin = await _adminRepository.GetByIdAsync(id);
                if (admin != null)
                {
                    await _adminRepository.DeleteAsync(admin);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the admin with ID {id}.", ex);
            }
        }
    }
}
