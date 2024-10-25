using Application.Exceptions;
using Application.Interfaces;
using Application.Models.Requests;
using Domain.IRepositories;
using Domain.Models.Purchases;

namespace Application.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public ShoppingCart GetCartByClientId(int userId)
        {

            var cart = _shoppingCartRepository.GetCartByClientId(userId);

            if (cart == null)
            {
                throw new NotFoundException("cart not found");
            }
            return cart;
        }

        public bool AddProductToCart(int userId, AddOrRemoveProductToCartDto addProductToCartDto)
        {
            try
            {
                if (addProductToCartDto == null || addProductToCartDto.Quantity <= 0)
                {
                    return false;
                }

                var shoppingCart = _shoppingCartRepository.GetCartByClientId(userId);
                var existingProduct = _productRepository.GetById(addProductToCartDto.ProductId);

                if (existingProduct == null || existingProduct.StockQuantity < addProductToCartDto.Quantity)
                {
                    return false;
                }

                var cartProduct = shoppingCart.ShoppingCartProducts
                                              .FirstOrDefault(scp => scp.ProductId == addProductToCartDto.ProductId);

                if (cartProduct != null)
                {
                    cartProduct.Quantity += addProductToCartDto.Quantity;
                }
                else
                {
                    shoppingCart.ShoppingCartProducts.Add(new ShoppingCartProduct
                    {
                        ShoppingCartId = shoppingCart.ShoppingCartId,
                        ProductId = existingProduct.Id,
                        Product = existingProduct,
                        Quantity = addProductToCartDto.Quantity
                    });
                }

                _shoppingCartRepository.Update(shoppingCart);
                return true;
            }
            catch (Exception ex)
            {
                throw new ValidateException("Error adding product to cart", ex);
            }
        }

        public bool RemoveProductFromCart(int userId, AddOrRemoveProductToCartDto productToRemoveDto)
        {
            try
            {
                if (productToRemoveDto == null || productToRemoveDto.Quantity <= 0)
                {
                    return false;
                }

                var shoppingCart = _shoppingCartRepository.GetCartByClientId(userId);

                if (shoppingCart == null || shoppingCart.ShoppingCartProducts.Count == 0)
                {
                    return false;
                }

                var cartProduct = shoppingCart.ShoppingCartProducts
                                              .FirstOrDefault(scp => scp.ProductId == productToRemoveDto.ProductId);

                if (cartProduct == null || cartProduct.Quantity < productToRemoveDto.Quantity)
                {
                    return false;
                }

                if (cartProduct.Quantity > productToRemoveDto.Quantity)
                {
                    cartProduct.Quantity -= productToRemoveDto.Quantity;
                }
                else
                {
                    shoppingCart.ShoppingCartProducts.Remove(cartProduct);
                }

                _shoppingCartRepository.Update(shoppingCart);
                return true;
            }
            catch (Exception ex)
            {
                throw new ValidateException("Error removing product from cart", ex);
            }
        }

        public List<ShoppingCart> GetAll()
        {

            return _shoppingCartRepository.GetAll();
        }

        public ShoppingCart GetById(int id)
        {
            var shoppingCart = _shoppingCartRepository.GetById(id);
            if (shoppingCart == null)
            {
                throw new NotFoundException($"Cart with ID {id} not found");
            }
            return shoppingCart;
        }

        public void Delete(int id)
        {
            try
            {
                var shoppingCart = _shoppingCartRepository.GetById(id);
                _shoppingCartRepository.Delete(shoppingCart);
            }
            catch (Exception ex)
            {
                throw new NotFoundException($"cart number {id} doesn't exist", ex);
            }
        }
    }
}
