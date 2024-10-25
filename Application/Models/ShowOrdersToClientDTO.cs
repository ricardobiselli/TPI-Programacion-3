using Domain.Models.Purchases;

namespace Application.Models
{
    public class ShowOrdersToClientDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public List<OrderDetailDTO> OrderDetails { get; set; }

        public static ShowOrdersToClientDTO Create(Order order)
        {
            return new ShowOrdersToClientDTO
            {
                Id = order.OrderId,
                TotalAmount = order.TotalAmount,
                OrderDate = order.OrderDate,
                OrderDetails = order.OrderDetails.Select(OrderDetailDTO.Create).ToList()
            };
        }
    }
}
