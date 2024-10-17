using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Application.Interfaces
{
    public interface IClientService : IBaseService<Client, int>
    {
        public void Update(int id, Client updatedClient);
    }
}
