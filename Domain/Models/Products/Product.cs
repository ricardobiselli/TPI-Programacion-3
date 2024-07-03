using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Models.Purchases;


namespace Domain.Models.Products
{
    public class Product
    {
        public Product(){ }
        public Product(string name, string description, string category, decimal price, int stock, int power)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            StockQuantity = stock;
            PowerConsumption = power;
            Orders = new List<Order>();
            ShoppingCarts = new List<ShoppingCart>();
            Compatibilities = new List<Compatibility>();

        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
        public decimal PowerConsumption { get; set; }

        public ICollection<Compatibility>? Compatibilities { get; set; } // one to one
        public ICollection<Order>? Orders { get; set; } // many to many
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; } // many to many
    }
}
