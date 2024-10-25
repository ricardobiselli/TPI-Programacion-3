using Application.Models.Requests;
using Domain.Models.Purchases;

namespace Application.Interfaces
{
    public interface IShoppingCartService
    {
        public bool AddProductToCart(int userId, AddOrRemoveProductToCartDto productToAddOrRemove);
        public ShoppingCart GetCartByClientId(int userId);
        public bool RemoveProductFromCart(int userId, AddOrRemoveProductToCartDto productToAddOrRemove);
        public List<ShoppingCart> GetAll();
        public ShoppingCart GetById(int id);
        public void Delete(int id);


    }
}
