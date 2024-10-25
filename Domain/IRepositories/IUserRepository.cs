using Domain.Models.Users;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailOrUsername(string emailOrUsername);

    }
}
