using Domain.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IUserRepository
    {
        User? GetUserByUserName(string username);

    }
}
