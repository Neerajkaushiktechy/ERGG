using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErgCentral.Repository.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Dispose();
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetAll();
        void Insert(TEntity entity);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void InsertAll(List<TEntity> entities);
        void DeleteAll(List<TEntity> entities);
        void UpdateAll(List<TEntity> entities);
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        List<TEntity> Get(int limit, int skip, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        List<TResult> GetAs<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TResult : class;
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetAsync(int limit, int skip, Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        bool Any(Expression<Func<TEntity, bool>> filter);

    }
}
