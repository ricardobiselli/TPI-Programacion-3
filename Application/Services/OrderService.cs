using Application.Exceptions;
using Application.Interfaces;
using Domain.IRepositories;
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

            var shoppingCart = _shoppingCartRepository.GetCartByClientId(userId);
            if (shoppingCart.ShoppingCartProducts.Count == 0)
            {
                throw new ValidateException("The shopping cart is empty!");
            }

            decimal totalAmount = shoppingCart.ShoppingCartProducts
                .Sum(product => product.Quantity * product.Product.Price);

            var order = new Order(totalAmount, userId, shoppingCart.ShoppingCartId);
           
            foreach (var cartProduct in shoppingCart.ShoppingCartProducts)
            {
                var product = _productRepository.GetById(cartProduct.ProductId);
                if (product.StockQuantity < cartProduct.Quantity)
                {
                    throw new ValidateException($"Insufficient stock for product {product.Name}");
                }

                var orderDetail = new OrderDetail
                (
                    cartProduct.ProductId, order.OrderId, cartProduct.Quantity, cartProduct.Product.Price
                );

                order.OrderDetails.Add(orderDetail);
                product.StockQuantity -= cartProduct.Quantity;
                _productRepository.Update(product);
            }

            _orderRepository.Add(order);
            shoppingCart.ShoppingCartProducts.Clear();
            _shoppingCartRepository.Update(shoppingCart);

            return order;

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
                throw new NotFoundException("Error retrieving orders by client ID", ex);
            }
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public Order GetById(int id)
        {

            var order = _orderRepository.GetById(id);
            if (order == null)
            {
                throw new NotFoundException($"Order with ID {id} not found");
            }
            return order;

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
                throw new NotFoundException($"Error deleting order {id}", ex);
            }
        }
    }
}


