using Domain.Models.Purchases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Models.Products;

namespace Application.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
        public decimal PowerConsumption { get; set; }
        [JsonIgnore]
        public ICollection<OrderDetailDTO> OrderDetails { get; set; }
        [JsonIgnore]
        public ICollection<ShoppingCartProductDTO> ShoppingCartItems { get; set; }

        public static ProductDto Create(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
                Category = product.Category,
                PowerConsumption = product.PowerConsumption,

            };
        }

    }

}
