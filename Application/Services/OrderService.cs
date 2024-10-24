using Application.Exceptions;
using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models.Products;
using Domain.Models.Purchases;

namespace Application.Services
{
    public class OrderService : IOrderService

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OrderService(IOrderRepository orderRepository,
                           IProductRepository productRepository,
                           IShoppingCartRepository shoppingCartRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public Order PlaceAnOrderFromCartContent(int userId)
        {
            try
            {
                var shoppingCart = _shoppingCartRepository.GetCartByClientId(userId);
                if (shoppingCart.ShoppingCartProducts.Count == 0)
                {
                    throw new ServiceException("The shopping cart is empty!");
                }

                decimal totalAmount = shoppingCart.ShoppingCartProducts
                    .Sum(product => product.Quantity * product.Product.Price);

                var order = new Order(totalAmount, userId)
                {
                    ShoppingCartId = shoppingCart.ShoppingCartId
                };

                foreach (var cartProduct in shoppingCart.ShoppingCartProducts)
                {
                    var product = _productRepository.GetById(cartProduct.ProductId);
                    if (product.StockQuantity < cartProduct.Quantity)
                    {
                        throw new ServiceException($"Insufficient stock for product {product.Name}");
                    }

                    var orderDetail = new OrderDetail
                    {
                        ProductId = cartProduct.ProductId,
                        Quantity = cartProduct.Quantity,
                        UnitPrice = cartProduct.Product.Price,
                        Subtotal = cartProduct.Quantity * cartProduct.Product.Price,
                        Order = order
                    };

                    order.OrderDetails.Add(orderDetail);
                    product.StockQuantity -= cartProduct.Quantity;
                    _productRepository.Update(product);
                }

                _orderRepository.Add(order);
                shoppingCart.ShoppingCartProducts.Clear();
                _shoppingCartRepository.Update(shoppingCart);

                return order;
            }
            catch (ServiceException)
            {
                throw;  
            }
            catch (Exception ex)
            {
                
                throw new ServiceException("Error placing order from cart content", ex);
            }
        }


        public List<Order> GetOrdersByClientId(int clientId)
        {
            try
            {
                return _orderRepository.GetOrdersWithDetails(clientId)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving orders by client ID", ex);
            }
        }

        public List<Order> GetAll()
        {
            try
            {
                return _orderRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving all orders", ex);
            }
        }

        public Order GetById(int id)
        {
            try
            {
                var order = _orderRepository.GetById(id);
                if (order == null)
                {
                    throw new NotFoundException($"Order with ID {id} not found");
                }
                return order;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving order by ID", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var order = GetById(id);
                _orderRepository.Delete(order);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error deleting order", ex);
            }
        }
    }
}


    