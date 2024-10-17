using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.IRepositories;
using Domain.Models.Products;

namespace Domain.IRepositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        
    }
}
