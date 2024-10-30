using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            var productDtos = products

            .Where(p => p.State == EntitiesState.Active)
            .Select(ProductDto.Create)
            .ToList();

            if (!productDtos.Any())
            {
                return NotFound(new { message = "List of Products in empty" });
            }
            return Ok(productDtos);
        }

        [HttpGet("Get-One/{id}")]
        [AllowAnonymous]
        public ActionResult<ProductDto> GetById(int id)
        {

            var product = _productService.GetById(id);
            var productDto = ProductDto.Create(product);
            return Ok(productDto);

        }

        [HttpPost("Add-Product")]
        public ActionResult<AddProductForAdminsDTO> Add(AddProductForAdminsDTO productDto)
        {
            if (!IsAdminOrSuperAdmin())
            {
                return Forbid();
            }

            var createdProduct = _productService.AddProduct(productDto);

            return Ok(createdProduct);
        }

        [HttpPut("Update-Product")]
        public ActionResult Update(UpdateProductDto productDto)
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
            _productService.Delete(id);
            return NoContent();

        }

    }
}