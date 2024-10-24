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
using Application.Models;
using System.Net;
using System.Numerics;
using Application.Exceptions;
using Domain.Models.Products;

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
            try
            {
                return _clientRepository.GetClientByIdWithDetailsIncluded(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving client with details", ex);
            }
        }

        public void UpdateClient(ClientDTO clientDto)
        {
            try
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
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error updating client", ex);
            }
        }

        public Client Add(ClientDTO clientDTO)
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
            catch (Exception ex)
            {
                throw new ServiceException("Error adding client", ex);
            }
        }

        public List<Client> GetAll()
        {
            try
            {
                return _clientRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving clients", ex);
            }
        }

        public Client GetById(int id)
        {
            try
            {
                var client = _clientRepository.GetById(id);
                if (client == null)
                {
                    throw new NotFoundException($"client with ID {id} not found");
                }
                return client;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving client by ID", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var client = GetById(id);
                _clientRepository.Delete(client);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error deleting client", ex);
            }
        }

    }
}
