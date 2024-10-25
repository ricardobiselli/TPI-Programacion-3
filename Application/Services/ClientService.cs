using Application.Exceptions;
using Application.Interfaces;
using Application.Models.Requests;
using Domain.Enums;
using Domain.IRepositories;
using Domain.Models.Users;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public Client GetByIdWithDetailsIncluded(int id)
        {
            var client = _clientRepository.GetClientByIdWithDetailsIncluded(id);
            if (client == null)
            {
                throw new ServiceException($"Error retrieving client number {id} with details");
            }
            return client;
        }

        public void UpdateClient(ClientUpdateDto clientDto)
        {
            var client = _clientRepository.GetById(clientDto.Id);

            if (client == null)
            {
                throw new NotFoundException($"Client with ID {clientDto.Id} not found");
            }

            client.UserName = clientDto.UserName;
            client.Email = clientDto.Email;
            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.Address = clientDto.Address;
            client.DniNumber = clientDto.DniNumber;

            _clientRepository.Update(client);
        }


        public Client Add(AddClientDTO clientDTO)
        {
            try
            {
                var newClient = new Client
                {
                    UserName = clientDTO.UserName,
                    Email = clientDTO.Email,
                    FirstName = clientDTO.FirstName,
                    LastName = clientDTO.LastName,
                    Address = clientDTO.Address,
                    Password = clientDTO.Password,
                    DniNumber = clientDTO.DniNumber
                };

                _clientRepository.Add(newClient);
                return newClient;
            }

            catch (ServiceException ex)
            {
                throw new ServiceException("Error adding client", ex);
            }
        }

        public List<Client> GetAll()
        {
            return _clientRepository.GetAll();
        }


        public Client GetById(int id)
        {

            var client = _clientRepository.GetById(id);
            if (client == null)
            {
                throw new NotFoundException($"client with ID {id} not found");
            }
            return client;

        }

        public void Delete(int id)
        {
            var clientForSoftDeletion = GetById(id);

            if (clientForSoftDeletion == null)
            {
                throw new NotFoundException($"Error deleting client with id {id} (not found)");
            }

            clientForSoftDeletion.State = EntitiesState.Deleted;
            _clientRepository.Update(clientForSoftDeletion);

        }
    }
}
