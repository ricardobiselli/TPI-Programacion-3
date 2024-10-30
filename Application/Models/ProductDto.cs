using Domain.Models.Products;
using System.Text.Json.Serialization;

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

        public static ProductDto Create(Product product)
        {
            return new ProductDto
            {
                Id = product.ProductId,
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
