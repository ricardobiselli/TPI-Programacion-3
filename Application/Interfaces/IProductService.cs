using Application.Exceptions;
using Application.Models;
using Domain.IRepositories;
using Domain.Models.Products;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductService 
    {
        public Product AddProduct(AddOrUpdateProductDto productDto);
        public Product UpdateProduct(AddOrUpdateProductDto productDto);
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Delete(int id);
    }
}

