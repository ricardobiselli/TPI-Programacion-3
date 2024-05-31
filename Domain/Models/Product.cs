using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace Domain.Models
    {
        public class Product
        {
            public Product() { }

            public Product(string name, string description, string category, decimal price, int stock, int power)
            {
                Name = name;
                Description = description;
                Category = category;
                Price = price;
                StockQuantity = stock;
                PowerConsumption = power;
            }

            public int Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }
            public int StockQuantity { get; set; }
            public string Category { get; set; }
            public List<Compatibility> Compatibilities { get; set; } = new List<Compatibility>();
            public int PowerConsumption { get; set; }
            //public Order Order { get; set; }
          
        }

        
    }

