﻿using Domain.Models.Products;

namespace Application.Models.Requests
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? Category { get; set; }
        public decimal PowerConsumption { get; set; }

        public static UpdateProductDto Create(Product product)
        {
            return new UpdateProductDto
            {
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
