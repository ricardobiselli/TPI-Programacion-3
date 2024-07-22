using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.IRepositories;
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

        public async Task<Product> GetByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while retrieving the product with ID {id}.", ex);
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                return await _productRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving all products.", ex);
            }
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the product.", ex);
            }
        }

        public async Task UpdateAsync(Product product)
        {
            try
            {
                await _productRepository.UpdateAsync(product);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the product.", ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(id);
                if (product != null)
                {
                    await _productRepository.DeleteAsync(product);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while deleting the product with ID {id}.", ex);
            }
        }
    }
}
