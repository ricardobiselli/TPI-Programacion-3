using Application.Interfaces;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public abstract class BaseService<T, TId> : IBaseService<T, TId> where T : class
    {
        protected readonly IRepositoryBase<T> _repository;

        protected BaseService(IRepositoryBase<T> repository)
        {
            _repository = repository;
        }

        public virtual List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(TId id)
        {
            return _repository.GetById(id);
        }

        public virtual void Delete(TId id)
        {
            var entity = _repository.GetById(id);

            _repository.Delete(entity);

        }

        public virtual void Add(T entity)

        {
            _repository.Add(entity);
        }


        public virtual void Update(T entity)
        {
            _repository.Update(entity);

        }

    }
}

