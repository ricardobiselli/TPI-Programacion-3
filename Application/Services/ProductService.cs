using Application.Exceptions;
using Application.Interfaces;
using Application.Models.Requests;
using Domain.Enums;
using Domain.IRepositories;
using Domain.Models.Products;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddProduct(AddProductForAdminsDTO productDto)
        {
            try
            {

                var productToAdd = new Product(
                        productDto.Name,
                        productDto.Description,
                        productDto.Category,
                        productDto.Price,
                        productDto.StockQuantity,
                        productDto.PowerConsumption
                 );


                _productRepository.Add(productToAdd);
                return productToAdd;
            }
            catch (Exception ex)
            {
                throw new ValidateException("Something went wrong while adding product!", ex);
            }
        }

        public Product UpdateProduct(UpdateProductDto productDto)
        {
            var productToUpdate = _productRepository.GetById(productDto.Id);

            if (productToUpdate == null)
            {
                throw new NotFoundException($"Product with ID {productDto.Id} not found.");
            }

            productToUpdate.Name = productDto.Name;
            productToUpdate.Description = productDto.Description;
            productToUpdate.Price = productDto.Price;
            productToUpdate.StockQuantity = productDto.StockQuantity;
            productToUpdate.Category = productDto.Category;
            productToUpdate.PowerConsumption = productDto.PowerConsumption;

            _productRepository.Update(productToUpdate);
            return productToUpdate;
        }

        public List<Product> GetAll()
        {
            var products = _productRepository.GetAll();
            return products ?? new List<Product>();
        }

        public Product GetById(int id)
        {

            var product = _productRepository.GetById(id);
            if (product == null)
            {
                throw new NotFoundException($"Product with ID {id} not found");
            }
            return product;
        }

        public void Delete(int id)
        {
            var product = _productRepository.GetById(id);

            if (product == null)
            {
                throw new NotFoundException($"Product with ID {id} not found.");
            }

            product.State = EntitiesState.Deleted;

            _productRepository.Update(product);
        }
    }
}


