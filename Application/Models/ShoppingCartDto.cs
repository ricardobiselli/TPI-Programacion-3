using Domain.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
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