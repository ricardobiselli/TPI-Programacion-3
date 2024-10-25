using Application.Models.Requests;
using Domain.Models.Products;

namespace Application.Interfaces
{
    public interface IProductService
    {
        public Product AddProduct(AddProductForAdminsDTO productDto);
        public Product UpdateProduct(UpdateProductDto productDto);
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Delete(int id);
    }
}

