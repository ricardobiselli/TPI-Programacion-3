using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Purchases
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client Client { get; set; }
        [ForeignKey("ShoppingCartId")]

        public int? ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public Order(decimal totalAmount, int clientId)
        {
            OrderDate = DateTime.Now;
            TotalAmount = totalAmount;
            ClientId = clientId;
            OrderDetails = new List<OrderDetail>();

        }
    }
}
