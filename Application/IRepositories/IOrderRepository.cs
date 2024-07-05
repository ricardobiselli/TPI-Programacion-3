using Domain.Models.Products;
using Domain.Models.Purchases;
using Domain.Models.Users;

namespace Infrastructure.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<Client> GetClientByIdAsync(int clientId);
        Task<List<Product>> GetProductsByIdsAsync(List<int> productIds);
        Task<List<Order>> GetOrdersByClientIdAsync(int clientId);
        Task AddOrderAsync(Order order);
    }
}
