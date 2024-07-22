using System.Collections.Generic;
using System.Threading.Tasks;
using Application.IRepositories;
using Domain.Models.Products;

namespace Application.IRepositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        
    }
}
