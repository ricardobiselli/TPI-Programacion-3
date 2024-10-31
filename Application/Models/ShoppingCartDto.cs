using Domain.Models.Purchases;
using System.Text.Json.Serialization;

namespace Application.Models
{
    public class ShoppingCartDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int ClientId { get; set; }
        public List<ShoppingCartProductDTO> ShoppingCartProducts { get; set; }

        public static ShoppingCartDto Create(ShoppingCart shoppingCart)
        {
            return new ShoppingCartDto
            {
                Id = shoppingCart.ShoppingCartId,
                ClientId = shoppingCart.ClientId,
                ShoppingCartProducts = shoppingCart.ShoppingCartProducts.Select(ShoppingCartProductDTO.Create).ToList()
            };
        }
    }
}