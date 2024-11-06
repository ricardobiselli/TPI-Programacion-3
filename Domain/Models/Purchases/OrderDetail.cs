using Domain.Models.Products;

namespace Domain.Models.Purchases
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }

        public OrderDetail(int productId, int orderId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            OrderId = orderId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Subtotal = quantity * unitPrice;
        }
    }
}