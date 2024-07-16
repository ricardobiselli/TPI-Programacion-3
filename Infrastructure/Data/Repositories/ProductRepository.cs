
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.IRepositories;
using Domain.Models.Products;
using static Infrastructure.Data.Repositories.ProductRepository;

namespace Infrastructure.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

//        public class StudentRepository : RepositoryBase<Student>, IStudentRepository
//        {
//            private readonly ApplicationDbContext _context;

//            public StudentRepository(ApplicationDbContext context) : base(context)
//            {
//                _context = context;

//            }

//            public async Task<Product> GetByIdAsync(int id)
//        {
//            return await _context.Products.FindAsync(id);
//        }

//        public async Task<IEnumerable<Product>> GetAllAsync()
//        {
//            return await _context.Products.ToListAsync();
//        }

//        public async Task AddAsync(Product product)
//        {
//            _context.Products.Add(product);
//            Console.WriteLine(product);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Product product)
//        {
//            _context.Products.Update(product);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var product = await _context.Products.FindAsync(id);
//            if (product != null)
//            {
//                _context.Products.Remove(product);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
