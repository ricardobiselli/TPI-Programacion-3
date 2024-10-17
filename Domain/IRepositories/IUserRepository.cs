using Domain.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        Task <User>GetUserByEmailOrUsername(string emailOrUsername);

    }
}
