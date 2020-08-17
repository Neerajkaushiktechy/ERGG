using System.Threading.Tasks;

namespace ErgCentral.Data.Base
{
    public interface IBaseCommand
    {
        void Add<TEntity>(TEntity entity) where TEntity : Entity;

        Task AddNow<TEntity>(TEntity entity) where TEntity : Entity;

        Task<int> SaveChangesAsync();
    }
}