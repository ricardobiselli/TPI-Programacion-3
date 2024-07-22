using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Products;
using Application.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace TPI_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "admin, superadmin")]
        public async Task<ActionResult<Product>> AddAsync(Product product)
        {
            await _productService.AddAsync(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin, superadmin")]
        public async Task<IActionResult> UpdateAsync(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productService.UpdateAsync(product);

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, superadmin")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(id);

            return NoContent();
        }
    }
}
