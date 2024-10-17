using Domain.IRepositories;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Domain.Models.Purchases;

namespace Application.Services
{
    public class ClientService : BaseService<Client, int>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository) : base(clientRepository) 
        {
            _clientRepository = clientRepository;
        }
        public override Client GetById(int id)
        {
            try
            {
                return _clientRepository.GetClientByIdWithDetailsIncluded(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load client with ID: {id}.", ex);
            }
        }

       
        public void Update(int id, Client updateClient)
        {
            try
            {
                var client =  _clientRepository.GetById(id);
                if (client != null)
                {
                    client.UserName = updateClient.UserName;
                    client.Email = updateClient.Email;
                    client.FirstName = updateClient.FirstName;
                    client.LastName = updateClient.LastName;
                    client.Address = updateClient.Address;
                    client.DniNumber = updateClient.DniNumber;

                     _clientRepository.Update(client);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while updating the client with ID {id}.", ex);
            }
        }

    }
}
