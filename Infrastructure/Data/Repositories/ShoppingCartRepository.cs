﻿
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

        public ShoppingCart? GetCartByClientId(int clientId)
        {
            return _context.ShoppingCarts
                .Include(sc => sc.Client)
                .Include(sc => sc.ShoppingCartProducts)
                    .ThenInclude(scp => scp.Product)

                .FirstOrDefault(sc => sc.ClientId == clientId);
        }

        public ShoppingCart? GetShoppingCartWithProducts(int shoppingCartId)
        {
            return _context.ShoppingCarts
                .Include(sc => sc.ShoppingCartProducts)
                    .ThenInclude(scp => scp.Product)
                .FirstOrDefault(sc => sc.ShoppingCartId == shoppingCartId);
        }
    }
}
