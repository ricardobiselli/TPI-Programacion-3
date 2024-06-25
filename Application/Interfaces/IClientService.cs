using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetByIdAsync(int id);
        Task<IEnumerable<Client>> GetAllAsync();
        Task AddAsync(Client client);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, Client updateClient);


    }
}
