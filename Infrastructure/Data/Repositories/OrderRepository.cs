
using Domain.Models.Users;
using Application.Interfaces;
using Domain.Models.Products;
using Domain.Models.Purchases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IClientService _clientService;

        public OrderRepository(ApplicationDbContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByClientIdAsync(int clientId)
        {
            return await _context.Orders
                .Where(o => o.ClientId == clientId)
                .ToListAsync();
        }

        public async Task AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            var client = await _clientService.GetByIdAsync(clientId);
            return client;
        }

        public async Task<List<Product>> GetProductsByIdsAsync(List<int> productIds)
        {
            return await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();
        }
    }
}

