using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Enums;
using Domain.IRepositories;
using Domain.Models.Users;


namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUserRepository _userRepository;

        public AdminService(IAdminRepository adminRepository, IUserRepository userRepository)
        {
            _adminRepository = adminRepository;
            _userRepository = userRepository;
        }

        public ShowAdminDto Add(AddNewAdminDTO addNewAdminDTO)
        {
            
            if (_userRepository.ExistsByUserName(addNewAdminDTO.UserName))
            {
                throw new ValidateException($"The username '{addNewAdminDTO.UserName}' is already taken");
            }

            if (_userRepository.ExistsByEmail(addNewAdminDTO.Email))
            {
                throw new ValidateException($"The email '{addNewAdminDTO.Email}' is already registered");
            }

            var newAdmin = new Admin(
                addNewAdminDTO.UserName,
                addNewAdminDTO.Email,
                addNewAdminDTO.Password
            );

            _adminRepository.Add(newAdmin);

            var createdAdmin = ShowAdminDto.Create(newAdmin);
            return createdAdmin;

            
        }
        public List<Admin> GetAll()
        {
            var admins = _adminRepository.GetAll();
            return admins ?? new List<Admin>();
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


            _adminRepository.Update(admin);
        }
    }
}




