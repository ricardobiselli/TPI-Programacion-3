using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Models.Products;
using Domain.Models.Users;

namespace Domain.Models.Purchases
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        [Key]
        public int CartId { get; set; }
        public ICollection<Product> Products { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }
    }
}
