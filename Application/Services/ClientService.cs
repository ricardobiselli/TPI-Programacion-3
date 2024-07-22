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
            try
            {
                return await _clientRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while retrieving the client with ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            try
            {
                return await _clientRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving all clients.", ex);
            }
        }

        public async Task AddAsync(Client client)
        {
            try
            {
                await _clientRepository.AddAsync(client);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the client.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var client = await _clientRepository.GetByIdAsync(id);
                if (client != null)
                {
                    await _clientRepository.DeleteAsync(client);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the client with ID {id}.", ex);
            }
        }

        public async Task UpdateAsync(int id, Client updateClient)
        {
            try
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
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the client with ID {id}.", ex);
            }
        }

    }
}
