using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> where T : class
    {
        private readonly DbContext _context;

        public RepositoryBase(DbContext context)
        {
            _context = context;
        }

        public virtual List<T> GetAll()
        {
            return  _context.Set<T>().ToList();
        }

        public virtual  T? GetById<Tid>(Tid id)
        {
            return  _context.Set<T>().Find([id]);
        }

        public  T Add(T entity) 

        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public   int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return  _context.SaveChanges();

        }

        public   int Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return  _context.SaveChanges();

        }


    }
}

