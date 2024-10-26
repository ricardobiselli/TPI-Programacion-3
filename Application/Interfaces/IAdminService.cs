using Application.Models;
using Application.Models.Requests;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        public ShowAdminDto Add(AddNewAdminDTO addNewAdminDTO);
        public List<Admin> GetAll();
        public Admin GetById(int id);
        public void Delete(int id);
        public void Update(UpdateAdminDTO updateAdminDTO);
    }
}










