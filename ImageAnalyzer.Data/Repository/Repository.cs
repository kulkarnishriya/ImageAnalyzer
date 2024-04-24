
using ImageAnalyzer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ImageAnalyzer.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Delete(Guid id)
        {
            T entity = GetById(id);
            _context.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
