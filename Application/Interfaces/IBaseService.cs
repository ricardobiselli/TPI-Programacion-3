using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public  interface IBaseService<T, Tid> where T : class
    {
        List <T> GetAll();
        T GetById(Tid id);
        void Delete(Tid id);
        void Add(T entity);
        void Update(T entity);


    }
}
