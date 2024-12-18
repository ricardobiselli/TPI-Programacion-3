﻿using Domain.Models.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Purchases
{
    public class ShoppingCartProduct
    {
        public int ShoppingCartProductID { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public ShoppingCartProduct()
        { }
        public ShoppingCartProduct(int shoppingcartId, int productId, Product product, int quantity)
        {
            ShoppingCartId = shoppingcartId;
            ProductId = productId;
            Product = product;
            Quantity = quantity;

        }

    }
}
