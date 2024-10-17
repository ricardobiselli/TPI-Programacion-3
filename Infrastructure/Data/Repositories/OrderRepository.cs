using Domain.IRepositories;
using Domain.Models.Purchases;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        public OrderRepository(ApplicationDbContext context, IClientRepository clientRepository, IProductRepository productRepository)
            : base(context)
        {
            _context = context;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }
    }
}
