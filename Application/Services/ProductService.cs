using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.IRepositories;
using Domain.Models.Products;

namespace Application.Services
{
    public class ProductService : BaseService<Product, int>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }


    }

}
