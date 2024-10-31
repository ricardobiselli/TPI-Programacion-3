using Domain.Models.Purchases;
using System.Text.Json.Serialization;

namespace Application.Models
{
    public class ShoppingCartProductDTO
    {
        [JsonIgnore]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public static ShoppingCartProductDTO Create(ShoppingCartProduct shoppingCartProduct)
        {
            return new ShoppingCartProductDTO
            {
                ProductId = shoppingCartProduct.ProductId,
                ProductName = shoppingCartProduct.Product.Name,
                Quantity = shoppingCartProduct.Quantity,
                UnitPrice = shoppingCartProduct.Product.Price
            };
        }
    }
}

