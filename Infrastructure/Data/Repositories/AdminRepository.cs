using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Users;
using Application.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Products;

namespace Infrastructure.Data.Repositories
{
    public class AdminRepository : RepositoryBase<Admin>, IAdminRepository
    {
       private readonly ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}



//    public async Task AddAsync(Admin admin)
//        {
//            await _context.Admins.AddAsync(admin);
//            await _context.SaveChangesAsync();
//        }

//        public async Task<IEnumerable<Admin>> GetAllAsync()
//        {
//            return await _context.Admins.ToListAsync();
//        }

//        public async Task<Admin> GetByIdAsync(int id)
//        {
//            return await _context.Admins.FindAsync(id);
//        }

//        public async Task UpdateAsync(Admin admin)
//        {
//            _context.Admins.Update(admin);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var admin = await _context.Admins.FindAsync(id);
//            if (admin != null)
//            {
//                _context.Admins.Remove(admin);
//                await _context.SaveChangesAsync();
//            }
//        }
//    }
//}
