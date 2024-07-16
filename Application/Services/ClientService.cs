using Application.IRepositories;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
             var client = await _clientRepository.GetByIdAsync(id);
            if (client != null) 
            {
                await _clientRepository.DeleteAsync(client);
            }
        }

        public async Task UpdateAsync(int id, Client updateClient)
        {
            var client = await _clientRepository.GetByIdAsync(id);
            if (client != null)
            {
                client.UserName = updateClient.UserName;
                client.Email = updateClient.Email;
                client.FirstName = updateClient.FirstName;
                client.LastName = updateClient.LastName;
                client.Address = updateClient.Address;
                client.DniNumber = updateClient.DniNumber;


    


                await _clientRepository.UpdateAsync(client);
            }
        }

    }
}
