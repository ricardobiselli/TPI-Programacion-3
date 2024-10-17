using Application.Interfaces;
using Domain.Models.Products;
using Domain.Models.Purchases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.Requests;

namespace TPI_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("{clientId}")]
        public ActionResult<ShoppingCart> GetShoppingCart(int clientId)
        {
            var shoppingCart = _shoppingCartService.GetCartByClientId(clientId);
            if (shoppingCart == null)
            {
                return NotFound("Shopping cart not found.");
            }
            return Ok(shoppingCart);
        }

        [HttpGet]
        public ActionResult<List<ShoppingCart>> GetAll()
        { 
            var allShoppingCarts = _shoppingCartService.GetAll()
                .ToList();
            return Ok(allShoppingCarts);
        }

        [HttpGet("/GetCartByCartId/{id}")]
        public ActionResult Get( int id) 
        {
            var shoppingCart = _shoppingCartService.GetById(id);
            if (shoppingCart == null)

            {
                return NotFound("product doesnt exist");
            }
            else {
                return Ok(shoppingCart);
            }
        }

        [HttpPost("{clientId}/add-product")]
        public ActionResult AddProductToCart(int clientId, [FromBody] AddProductToCartDto addProductToCartDto)
        {
            if (addProductToCartDto == null || addProductToCartDto.Quantity <= 0)
            {
                return BadRequest("Invalid product details or quantity.");
            }

            var product = new Product
            {
                Id = addProductToCartDto.ProductId
            };

            _shoppingCartService.AddProductToCart(clientId, product, addProductToCartDto.Quantity);
            return Ok("Product added to cart successfully.");
        }

        [HttpDelete("remove-product/")]
        public ActionResult RemoveProductFromCart(int clientId, int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("Quantity must be greater than zero.");
            }

            var shoppingCart = _shoppingCartService.GetCartByClientId(clientId);
            if (shoppingCart == null)
            {
                return NotFound("Shopping cart not found.");
            }

            var cartProduct = shoppingCart.ShoppingCartProducts.FirstOrDefault(x => x.ProductId == productId);
            if (cartProduct == null)
            {
                return NotFound("Product not found in the shopping cart.");
            }

            if (cartProduct.Quantity < quantity)
            {
                return BadRequest("Cannot remove more than available quantity.");
            }

            _shoppingCartService.RemoveProductFromCart(clientId, productId, quantity);
            return Ok("Product removed from cart successfully.");
        }
    }
}
