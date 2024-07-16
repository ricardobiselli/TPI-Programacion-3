using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface IRepositoryBase<T> where T : class
    {
        public Task <List<T>> GetAllAsync();

        public Task<T?> GetByIdAsync<Tid>(Tid id);

        public Task<T> AddAsync(T entity);

        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteAsync(T entity);



    }
}
   
