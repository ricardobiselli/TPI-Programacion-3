using Domain.IRepositories;
using Domain.Models.Purchases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;


        public OrderRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;

        }
        public List<Order> GetOrdersWithDetails(int clientId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Where(o => o.ClientId == clientId)
                .ToList();
        }
    }
}
