using Domain.IRepositories;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        private readonly ApplicationDbContext _context;
        public ClientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Client? GetClientByIdWithDetailsIncluded(int id)
        {
            return _context.Clients
                .Include(x => x.ShoppingCart)
                    .ThenInclude(x => x.ShoppingCartProducts)
                        .ThenInclude(x => x.Product)  
                .Include(x => x.Orders)
                    .ThenInclude(x => x.OrderDetails)
                        .ThenInclude(x => x.Product)  
                .FirstOrDefault(x => x.Id == id);
        }

        public override List<Client> GetAll()
        {
            return _context.Clients
                .Include(x => x.ShoppingCart)
                    .ThenInclude(x => x.ShoppingCartProducts)
                        .ThenInclude(x => x.Product)
                .Include(x => x.Orders)
                    .ThenInclude(x => x.OrderDetails)
                        .ThenInclude(x => x.Product)
                .ToList();
        }

    }
}