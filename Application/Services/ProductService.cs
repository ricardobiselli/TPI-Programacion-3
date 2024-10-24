using System;
using System.Collections.Generic;
using Application.Exceptions;
using Application.Interfaces;
using Application.Models;
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

        public Product AddProduct(AddOrUpdateProductDto productDto)
        {
            var productToAdd = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                StockQuantity = productDto.StockQuantity
            };

            _productRepository.Add(productToAdd);
            return productToAdd;
        }

        public Product UpdateProduct(AddOrUpdateProductDto productDto)
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
            try
            {
                return _productRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving products", ex);
            }
        }

        public Product GetById(int id)
        {
            try
            {
                var product = _productRepository.GetById(id);
                if (product == null)
                {
                    throw new NotFoundException($"Product with ID {id} not found");
                }
                return product;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error retrieving product by ID", ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var product = GetById(id);
                _productRepository.Delete(product);
            }
            catch (Exception ex)
            {
                throw new ServiceException("Error deleting product", ex);
            }
        }
    }
}
