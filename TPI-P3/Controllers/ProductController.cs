using Application.Interfaces;
using Domain.Models.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TPI_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [AllowAnonymous]
        public  ActionResult<IEnumerable<Product>> GetAll()
        {
            var products =  _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public  ActionResult<Product> GetById(int id)
        {
            var product =  _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("Add-Product")]
        //[Authorize(Roles = "admin, superadmin")]
        public  ActionResult<Product> Add(Product product)
        {
             _productService.Add(product);
            return Ok(product);
        }

        [HttpPut("Update-Product{id}")]
        //[Authorize(Roles = "admin, superadmin")]
        public  IActionResult Update(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

             _productService.Update(product);

            return NoContent();
        }
        
        [HttpDelete("Detele-Product/{id}")]
        //[Authorize(Roles = "admin, superadmin")]

        public  IActionResult Delete(int id)
        {
            var product =  _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

             _productService.Delete(id);

            return NoContent();
        }
    }
}
