using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ImageAnalyzer.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);  
        void Delete(Guid id);

    }
}
