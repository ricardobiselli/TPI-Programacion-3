using Application.Interfaces;
using Domain.Models.Products;
using Domain.Models.Purchases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Models.Requests;
using Application.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TPI_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShoppingCartController : RoleCheckController
    {
        private readonly IShoppingCartService _shoppingCartService;
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("Get-Cart-From-Client")]
        public ActionResult<ShoppingCartDto> GetShoppingCart()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
            var shoppingCart = _shoppingCartService.GetCartByClientId(userId);

            if (shoppingCart == null)

            {
                return NotFound();
            }

            var shoppingCartDto = ShoppingCartDto.Create(shoppingCart);
            return Ok(shoppingCartDto);
        }

        [HttpGet("Get-All-Shopping-Carts")]
        public ActionResult<List<ShoppingCartDto>> GetAll()
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var allShoppingCarts = _shoppingCartService.GetAll()
                .Select(ShoppingCartDto.Create)
                .ToList();

            return Ok(allShoppingCarts);
        }

        [HttpGet("Get-Any-Cart-By-Id/{id}")]
        public ActionResult<ShoppingCartDto> Get(int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var shoppingCart = _shoppingCartService.GetById(id);
            if (shoppingCart == null)

            {
                return NotFound();
            }
            else
            {
                var ShoppingCartDTO = ShoppingCartDto.Create(shoppingCart);
                return Ok(ShoppingCartDTO);
            }
        }

        [HttpPost("Add-Product-To-Cart")]
        public ActionResult AddProductToCart([FromBody] AddOrRemoveProductToCartDto addProductToCartDto)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");
                        
            if (!_shoppingCartService.AddProductToCart(userId, addProductToCartDto))
            {
                return BadRequest("Invalid product details or unable to add product!");
            }

            return Ok("Product added to cart successfully!");
        }

        [HttpDelete("Remove-Product-From-Cart")]
        public ActionResult RemoveProductFromCart( [FromBody] AddOrRemoveProductToCartDto productToRemoveDto)
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "");

            if (!_shoppingCartService.RemoveProductFromCart(userId, productToRemoveDto))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
