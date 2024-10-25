using Domain.Models.Purchases;

namespace Domain.IRepositories
{
    public interface IShoppingCartRepository : IRepositoryBase<ShoppingCart>
    {
        ShoppingCart GetCartByClientId(int clientId);
        ShoppingCart GetShoppingCartWithProducts(int shoppingCartId);
    }
}