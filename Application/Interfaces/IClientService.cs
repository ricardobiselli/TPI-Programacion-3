using Application.Models;
using Application.Models.Requests;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IClientService
    {
        public void UpdateClient(ClientUpdateDto clientDto);
        public ClientResponseDTO Add(AddClientDTO clientDTO);
        public Client GetByIdWithDetailsIncluded(int id);
        public List<Client> GetAll();
        public Client GetById(int id);
        public void Delete(int id);



    }
}
