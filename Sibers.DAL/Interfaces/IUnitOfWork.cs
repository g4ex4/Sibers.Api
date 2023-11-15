using Sibers.DAL.Common;

namespace Sibers.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity;
        public Task SaveChangesAsync();
    }
}
