using Domain.Models.Purchases;
using System.Text.Json.Serialization;
namespace Application.Models
{
    public class OrderDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        [JsonIgnore]
        public int ClientId { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }

        public static OrderDTO Create(Order order)
        {
            return new OrderDTO
            {
                Id = order.OrderId,
                TotalAmount = order.TotalAmount,
                ClientId = order.ClientId,
                OrderDate = order.OrderDate,
                OrderDetails = order.OrderDetails.Select(OrderDetailDTO.Create).ToList()
            };
        }
    }
}
