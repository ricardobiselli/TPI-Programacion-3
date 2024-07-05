using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Domain.Models.Purchases;


namespace Domain.Models.Products
{
    public class Product
    {
        public Product() { }
        public Product(string name, string description, string category, decimal price, int stock, int power, List<string> compatibilities)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            StockQuantity = stock;
            PowerConsumption = power;
            Orders = new List<Order>();
            //ShoppingCarts = new List<ShoppingCart>();
            Compatibilities = compatibilities;

        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
        public decimal PowerConsumption { get; set; }
        public List<string>? Compatibilities { get; set; } 

        public ICollection<Order>? Orders { get; set; } 
        //public ICollection<ShoppingCart>? ShoppingCarts { get; set; } 
    }
    
}

