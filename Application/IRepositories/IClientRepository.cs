using Application.IRepositories;
using Domain.Models.Products;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IClientRepository : IRepositoryBase<Client>
    {
       // Task<Client> GetByIdAsync(int id);
       // Task<IEnumerable<Client>> GetAllAsync();
       //  Task AddAsync(Client client);
       // Task DeleteAsync(int id);
       // Task UpdateAsync( Client client);
    }
}



