using Domain.Models.Products;
using Domain.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.Requests;

namespace Application.Interfaces
{
    public interface IShoppingCartService 
    {
        public bool AddProductToCart(int userId, AddOrRemoveProductToCartDto productToAddOrRemove);
        public ShoppingCart GetCartByClientId(int userId);
        public bool RemoveProductFromCart(int userId, AddOrRemoveProductToCartDto productToAddOrRemove);
        public List<ShoppingCart> GetAll();
        public ShoppingCart GetById(int id);
        public void Delete(int id);


    }
}
