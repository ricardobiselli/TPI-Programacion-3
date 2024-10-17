using Application.Models;
using Domain.Models.Purchases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IOrderService : IBaseService<Order, int>
    {
        public bool PlaceAnOrderFromCartContent(int clientId);




    }
}
