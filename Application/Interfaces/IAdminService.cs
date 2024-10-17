using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IAdminService : IBaseService<Admin, int>
    {
        public void Update(int id, Admin updatedAdmin);
    }
}