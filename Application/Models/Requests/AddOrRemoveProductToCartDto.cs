using Domain.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class AddOrRemoveProductToCartDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]

        public int Quantity { get; set; }

        public static AddOrRemoveProductToCartDto Create(Product product)
        {
            return new AddOrRemoveProductToCartDto
            {
                ProductId = product.ProductId,
                Quantity = product.StockQuantity,
            };
        }
    }
}
