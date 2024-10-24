using Domain.Models.Products;
using Domain.Models.Purchases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ShoppingCartProductDTO
    {
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

