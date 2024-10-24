using Application.Interfaces;
using Domain.Models.Products;
using Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Services;

namespace TPI_P3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ProductsController : RoleCheckController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Get-All")]
        [AllowAnonymous]
        public ActionResult<List<ProductDto>> GetAll()
        {
            var products = _productService.GetAll();

            if (products == null || products.Count == 0)
            {
                return NotFound();
            }
            else
            {
                var productDtos = products
                .Select(ProductDto.Create)
                .ToList();

                return Ok(productDtos);
            }
        }


        [HttpGet("Get-One/{id}")]
        [AllowAnonymous]
        public ActionResult<ProductDto> GetById(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = ProductDto.Create(product);
            return Ok(productDto);
        }

        [HttpPost("Add-Product")]
        public ActionResult<AddOrUpdateProductDto> Add(AddOrUpdateProductDto productDto)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }
            if (productDto == null)
            {
                return BadRequest();
            }
            else
            {
                var createdProduct = _productService.AddProduct(productDto);

                return Ok(createdProduct);
            }
        }

        [HttpPut("Update-Product")]
        public ActionResult Update(AddOrUpdateProductDto productDto)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            else
            {
                _productService.UpdateProduct(productDto);
                return NoContent();
            }
        }

        [HttpDelete("Delete-Product/{id}")]
        public ActionResult Delete(int id)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            _productService.Delete(id);
            return NoContent();
        }
    }
}