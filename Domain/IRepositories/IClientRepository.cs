using Domain.Models.Users;

namespace Domain.IRepositories
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
        public Client? GetClientByIdWithDetailsIncluded(int id);


    }
}



