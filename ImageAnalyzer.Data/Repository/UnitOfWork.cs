using ImageAnalyzer.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageAnalyzer.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext
    {
        private TContext _dbContext;
        private Dictionary<Type, object>? _repositories;
        
        public UnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
        }
            


        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(T);
            if(!_repositories.ContainsKey(type))
                _repositories[type] = new Repository<T>(_dbContext);
            return (IRepository<T>) _repositories[type];
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
