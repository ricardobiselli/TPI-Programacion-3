using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Users;
using Application.Interfaces;
using Domain.IRepositories;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }


    }
}