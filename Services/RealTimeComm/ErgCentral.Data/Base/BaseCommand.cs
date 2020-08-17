using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ErgCentral.Data.Base
{
    public abstract class BaseCommand<TContext> : IBaseCommand where TContext : DbContext
    {
        private readonly TContext _ctx;

        protected BaseCommand(TContext ctx)
        {
            _ctx = ctx;
        }

        public void Add<TEntity>(TEntity entity) where TEntity : Entity
        {
            _ctx.Add(entity);
        }

        public virtual async Task AddNow<TEntity>(TEntity entity) where TEntity : Entity
        {
            _ctx.Add(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _ctx.SaveChangesAsync();
        }
    }
}