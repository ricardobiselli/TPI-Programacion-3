using Domain.IRepositories;
using Domain.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IShoppingCartRepository : IRepositoryBase<ShoppingCart>
    {
        ShoppingCart GetByClientId(int clientId);
        ShoppingCart GetShoppingCartWithProducts(int shoppingCartId);
    }
}