using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models.Purchases;
//using Infrastructure.Data.Repositories;

namespace Application.Services
{
    public class OrderService : BaseService<Order, int>, IOrderService

    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public OrderService(IOrderRepository orderRepository,
                           IProductRepository productRepository,
                           IShoppingCartRepository shoppingCartRepository) : base(orderRepository) 
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
      
        public bool PlaceAnOrderFromCartContent(int clientId)
        {
            var shoppingCart = _shoppingCartRepository.GetByClientId(clientId);
            if (shoppingCart.ShoppingCartProducts.Count == 0)

            {
                throw new Exception("The shopping cart is empty!");
            }

            decimal totalAmount = shoppingCart.ShoppingCartProducts
                                      .Sum(product => product.Quantity * product.Product.Price);

            var order = new Order(totalAmount, clientId)
            {
                ShoppingCartId = shoppingCart.ShoppingCartId
            };

            foreach (var cartProduct in shoppingCart.ShoppingCartProducts)
            {
                var orderDetail = new OrderDetail
                {
                    ProductId = cartProduct.ProductId,
                    Quantity = cartProduct.Quantity,
                    UnitPrice = cartProduct.Product.Price,
                    Subtotal = cartProduct.Quantity * cartProduct.Product.Price,
                    Order = order
                };

                order.OrderDetails.Add(orderDetail);

                var product = _productRepository.GetById(cartProduct.ProductId);
                if (product.StockQuantity < cartProduct.Quantity)
                {
                    throw new Exception($"Insufficient stock for product {product.Name}");
                }
                product.StockQuantity -= cartProduct.Quantity;
                _productRepository.Update(product);
            }

            _orderRepository.Add(order);

            shoppingCart.ShoppingCartProducts.Clear();
            _shoppingCartRepository.Update(shoppingCart);
            return true;
        }
    }
}
    