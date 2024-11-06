using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Purchases
{
    public class Order
    {

        public int OrderId { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int? ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {}
        public Order(decimal totalAmount, int clientId, int shoppingcartId)
        {
            OrderDate = DateTime.Now;
            TotalAmount = totalAmount;
            ClientId = clientId;
            ShoppingCartId = shoppingcartId;
            OrderDetails = new List<OrderDetail>();

        }
    }
}
