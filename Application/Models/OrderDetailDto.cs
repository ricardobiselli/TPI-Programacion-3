using Domain.Models.Purchases;

namespace Application.Models
{

    public class OrderDetailDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        public static OrderDetailDTO Create(OrderDetail orderDetail)
        {
            return new OrderDetailDTO
            {
                ProductId = orderDetail.ProductId,
                ProductName = orderDetail.Product?.Name,
                Quantity = orderDetail.Quantity,
                UnitPrice = orderDetail.UnitPrice,
                Subtotal = orderDetail.Subtotal
            };
        }
    }
}

