using Domain.Models.Users;

namespace Domain.IRepositories
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        public Client? GetClientByIdWithDetailsIncluded(int id);
        bool ExistsByUserName(string userName);
        bool ExistsByEmail(string email);

    }
}



