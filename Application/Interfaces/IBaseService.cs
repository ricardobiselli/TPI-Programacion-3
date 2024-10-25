namespace Application.Interfaces
{
    public interface IBaseService<T, Tid> where T : class
    {
        List<T> GetAll();
        T GetById(Tid id);
        void Delete(Tid id);
        void Add(T entity);
        void Update(/*int id,*/ T entity);


    }
}
