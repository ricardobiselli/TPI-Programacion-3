using Application.IRepositories;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Client> GetByIdAsync(int id)
        {
            return await _clientRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _clientRepository.GetAllAsync();
        }

        public async Task AddAsync(Client client)
        {
            
            await _clientRepository.AddAsync(client);
        }

        public async Task DeleteAsync(int id)
        { 
              await _clientRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Client client)
        {
            await _clientRepository.UpdateAsync(client);
            
        }

    }
}
