using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Domain.Models.Products;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IClientService 
    {
        //public void Update(int id, Client updatedClient);
        public void UpdateClient(ClientDTO clientDto);
        public Client Add(ClientDTO clientDTO);
        public Client GetByIdWithDetailsIncluded(int id);
        public List<Client> GetAll();
        public Client GetById(int id);
        public void Delete(int id);



    }
}
