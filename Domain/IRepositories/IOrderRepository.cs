
using Domain.IRepositories;
using Domain.Models.Products;
using Domain.Models.Purchases;
using Domain.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        public List<Order> GetOrdersWithDetails(int clientId);
    }
}
