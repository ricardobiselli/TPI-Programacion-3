using Domain.Models.Products;
using Domain.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IShoppingCartService : IBaseService<ShoppingCart, int>
    {
        public void AddProductToCart(int clientId, Product product, int quantity);
        public ShoppingCart GetCartByClientId(int clientId);
        public void RemoveProductFromCart(int clientId, int productId, int quantity);
        

    }
}
