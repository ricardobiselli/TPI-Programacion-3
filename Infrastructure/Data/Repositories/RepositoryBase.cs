using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task <T?> GetByIdAsync<Tid>(Tid id)
        {
            return await _context.Set<T>().FindAsync(new object[] { id });
        }

        public async Task<T> AddAsync(T entity) //ver asincronía

        {
            _context.Set<T>().Add(entity);
            _context.SaveChangesAsync();
            return entity;
        }


        public async Task <int> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return await _context.SaveChangesAsync();

        }


        public async Task <int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();

        }


    }
}

