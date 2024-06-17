using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Models.Products;
using Domain.Models.Users;

namespace Domain.Models.Purchases
{
    public class Order
    {
        public Order(decimal totalAmount, int clientId)
        {
            OrderDate = DateTime.Now;
            TotalAmount = totalAmount;
            Products = new List<Product>();
        }

        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; } 
        public Client Client { get; set; }

        public ICollection<Product> Products { get; set; } //many to many
    }
}
