using System.Collections.Generic;
using System.Threading.Tasks;
using Application.IRepositories;
using Domain.Models.Products;

namespace Application.IRepositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        //Task<Product> GetByIdAsync(int id);
        //Task<IEnumerable<Product>> GetAllAsync();
        //Task AddAsync(Product product);
        //Task UpdateAsync(Product product);
        //Task DeleteAsync(int id);
    }
}
