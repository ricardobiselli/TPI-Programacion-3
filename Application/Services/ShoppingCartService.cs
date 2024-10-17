using Application.Interfaces;
using Domain.IRepositories;
using Domain.IRepositories;
using Domain.Models.Products;
using Domain.Models.Purchases;

namespace Application.Services
{
    public class ShoppingCartService : BaseService<ShoppingCart, int>, IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository): base(shoppingCartRepository) 
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }
        public ShoppingCart GetCartByClientId(int clientId)
        {
            return _shoppingCartRepository.GetByClientId(clientId);

        }
        public ShoppingCart Get(int shoppingCartId)
        {
            return _shoppingCartRepository.GetShoppingCartWithProducts(shoppingCartId);
        }


        public void AddProductToCart(int clientId, Product product, int quantity)
        {
            var shoppingCart = _shoppingCartRepository.GetByClientId(clientId);

            var existingProduct = _productRepository.GetById(product.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product does not exist");
            }

            if (existingProduct.StockQuantity < quantity)
            {
                throw new Exception("No stock available for that quantity");
            }
            var cartProduct = shoppingCart.ShoppingCartProducts
                                  .FirstOrDefault(x => x.ProductId == product.Id);

            if (cartProduct != null)
            {
                cartProduct.Quantity += quantity; 
            }
            else
            {
                shoppingCart.ShoppingCartProducts.Add(new ShoppingCartProduct
                {
                    ShoppingCartId = shoppingCart.ShoppingCartId,
                    ProductId = existingProduct.Id,
                    Product = existingProduct,
                    Quantity = quantity
                });
            }

            _shoppingCartRepository.Update(shoppingCart);
        }
      
        public void RemoveProductFromCart(int clientId, int productId, int quantity)
        {
            var shoppingCart = _shoppingCartRepository.GetByClientId(clientId);
            if (shoppingCart.ShoppingCartProducts.Count == 0)
            {
                throw new Exception("Shopping cart is empty");
            }

            var cartProduct = shoppingCart.ShoppingCartProducts
                                         .FirstOrDefault(x => x.ProductId == productId);

            if (cartProduct != null)
            {
                if (cartProduct.Quantity > quantity)
                {
                    cartProduct.Quantity -= quantity;
                }
                else
                {
                    shoppingCart.ShoppingCartProducts.Remove(cartProduct);
                }

                _shoppingCartRepository.Update(shoppingCart);
            }
            else
            {
                throw new Exception("Product not found in current cart");
            }
        }
    }
}
