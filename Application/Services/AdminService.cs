using Application.Exceptions;
using Application.Interfaces;
using Application.Models.Requests;
using Domain.Enums;
using Domain.IRepositories;
using Domain.Models.Users;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin Add(AddNewAdminDTO addNewAdminDTO)
        {
            try
            {
                var newAdmin = new Admin(
                    addNewAdminDTO.UserName,
                    addNewAdminDTO.Email,
                    addNewAdminDTO.Password
                );

                _adminRepository.Add(newAdmin);

                return newAdmin;
            }
            catch (Exception ex)
            {
                throw new ValidateException("Something went wrong while adding a new admin", ex);
            }
        }
        public List<Admin> GetAll()
        {
            return _adminRepository.GetAll();
        }

        public Admin GetById(int id)
        {
          
                var admin = _adminRepository.GetById(id);
                if (admin == null)
                {
                    throw new NotFoundException($"admin with ID {id} not found");
                }
                return admin;
            
        }

        public void Delete(int id)
        {
            var adminForSoftDeletion = _adminRepository.GetById(id);

            if (adminForSoftDeletion == null)
            {
                throw new NotFoundException($"admin with ID {id} not found");
            }

            adminForSoftDeletion.State = EntitiesState.Deleted;
            _adminRepository.Update(adminForSoftDeletion);
        }
        public void Update(UpdateAdminDTO updateAdminDTO)
        {
            var admin = _adminRepository.GetById(updateAdminDTO.Id);

            if (admin == null)
            {
                throw new NotFoundException($"Admin with ID {updateAdminDTO.Id} not found");
            }

            admin.UserName = updateAdminDTO.UserName;
            admin.Email = updateAdminDTO.Email;
            admin.Password = updateAdminDTO.Password;
           

            _adminRepository.Update(admin);
        }
    }
}




