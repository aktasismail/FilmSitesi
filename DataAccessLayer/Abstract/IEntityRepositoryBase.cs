using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IEntityRepositoryBase<T>
    {
        IQueryable<T> GetAll(bool trackchanges);
        IQueryable<T> Get(Expression<Func<T, bool>> expression, bool trackChanges);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
