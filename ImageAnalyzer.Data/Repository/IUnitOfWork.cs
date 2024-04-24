using Microsoft.EntityFrameworkCore;

namespace ImageAnalyzer.Repository
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        IRepository<T> GetRepository<T>() where T : class;

        int SaveChanges();

    }
}
