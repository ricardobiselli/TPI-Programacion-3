using System;
using System.Collections.Generic;
using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.IRepositories;
using Domain.Models.Products;
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
            try
            {
                return _shoppingCartRepository.GetCartByClientId(userId);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving cart by client ID", ex);
            }
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
                throw new ServiceException("Error adding product to cart", ex);
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
                throw new ServiceException("Error removing product from cart", ex);
            }
        }

        public List<ShoppingCart> GetAll()
        {
            try
            {
                return _shoppingCartRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving carts", ex);
            }
        }

        public ShoppingCart GetById(int id)
        {
            try
            {
                var shoppingCart = _shoppingCartRepository.GetById(id);
                if (shoppingCart == null)
                {
                    throw new NotFoundException($"Cart with ID {id} not found");
                }
                return shoppingCart;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving cart by ID", ex);
            }
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
                throw new ServiceException("Error deleting cart", ex);
            }
        }
    }
}
