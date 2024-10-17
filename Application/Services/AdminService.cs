using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Users;
using Application.Interfaces;
using Domain.IRepositories;

namespace Application.Services
{
    public class AdminService : BaseService<Admin, int>, IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository): base(adminRepository) 
        {
            _adminRepository = adminRepository;
        }


        public void Update(int id, Admin updatedAdmin)
        {
            try
            {
                var admin = _adminRepository.GetById(id);
                if (admin != null)
                {
                    admin.UserName = updatedAdmin.UserName;
                    admin.Email = updatedAdmin.Email;
                    admin.Password = updatedAdmin.Password;

                    _adminRepository.Update(admin);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the admin with ID {id}.", ex);
            }
        }


    }
}
