using Domain.Enums;
using Domain.Models.Purchases;
using System.ComponentModel.DataAnnotations;


namespace Domain.Models.Products
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
        public decimal PowerConsumption { get; set; }
        public EntitiesState State { get; set; } = EntitiesState.Active;
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<ShoppingCartProduct> ShoppingCartProducts { get; set; }
        public Product() { }
        public Product(string name, string description, string category, decimal price, int stock, int power)
        {
            Name = name;
            Description = description;
            Category = category;
            Price = price;
            StockQuantity = stock;
            PowerConsumption = power;
            OrderDetails = new List<OrderDetail>();
            ShoppingCartProducts = new List<ShoppingCartProduct>();
            State = EntitiesState.Active;
        }

    }

}

