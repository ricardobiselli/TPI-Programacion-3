using Domain.Models.Purchases;
using Domain.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Application.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
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
