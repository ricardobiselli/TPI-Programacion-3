using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Enums;
using Domain.IRepositories;
using Domain.Models.Users;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        public ClientService(IClientRepository clientRepository, IUserRepository userRepository)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
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


        public ClientResponseDTO Add(AddClientDTO addClientDTO)
        {

            if (_userRepository.ExistsByUserName(addClientDTO.UserName))
            {
                throw new ValidateException($"The username '{addClientDTO.UserName}' is already taken");
            }

            if (_userRepository.ExistsByEmail(addClientDTO.Email))
            {
                throw new ValidateException($"The email '{addClientDTO.Email}' is already registered");
            }
            var newClient = new Client
            {
                UserName = addClientDTO.UserName,
                Email = addClientDTO.Email,
                FirstName = addClientDTO.FirstName,
                LastName = addClientDTO.LastName,
                Address = addClientDTO.Address,
                Password = addClientDTO.Password,
                DniNumber = addClientDTO.DniNumber
            };

            _clientRepository.Add(newClient);
            var newClientToDto = ClientResponseDTO.Create(newClient);
            return newClientToDto;


        }

        public List<Client> GetAll()
        {
            var clients = _clientRepository.GetAll();
            return clients ?? new List<Client>();
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
