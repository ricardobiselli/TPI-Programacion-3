using Domain.IRepositories;
using Domain.Models.Purchases;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class ShoppingCartRepository : RepositoryBase<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext _context;
        public ShoppingCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public ShoppingCart GetByClientId(int clientId)
        {
            return _context.ShoppingCarts

                .Include(x => x.Client)
                    .ThenInclude(x => x.Orders)
                        .ThenInclude(x => x.OrderDetails)
                            .ThenInclude(x => x.Product)
                .Include(x => x.ShoppingCartProducts)
                    .ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.ClientId == clientId);
        }

        public ShoppingCart GetShoppingCartWithProducts(int shoppingCartId)
        {
            return _context.ShoppingCarts

            .Include(x => x.Client)
            .Include(x => x.ShoppingCartProducts)
                .ThenInclude(x => x.Product)
            .FirstOrDefault(x => x.ShoppingCartId == shoppingCartId);
        }
    }
}
