using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.EfCore
{
    public class EntityRepositoryBase<T> : IEntityRepositoryBase<T> where T : class
    {
        private readonly MovieDbContext _context;
        public EntityRepositoryBase(MovieDbContext context)
        {
            _context = context;
        }
        public void Create(T entity) =>
            _context.Set<T>().Add(entity);
        public void Delete(T entity) => 
            _context.Set<T>().Remove(entity);
        public IQueryable<T> Get(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking() :
            _context.Set<T>().Where(expression);
        public IQueryable<T> GetAll(bool trackchanges) =>
            !trackchanges ?
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>();
        public void Update(T entity) =>
            _context.Set<T>().Update(entity);
    }
}
