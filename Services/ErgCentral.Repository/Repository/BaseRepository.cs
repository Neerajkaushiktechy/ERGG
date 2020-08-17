using ErgCentral.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ErgCentral.Repository.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : class
    {
        #region Properties
        internal DbSet<TEntity> dbSet;
        internal ErgCentralContext _ergCentralContext;
        #endregion

        #region constructor
        public BaseRepository(ErgCentralContext ergCentralContext)
        {
            _ergCentralContext = ergCentralContext;
            this.dbSet = _ergCentralContext.Set<TEntity>();
        }
        #endregion


        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._ergCentralContext != null)
            {
                this._ergCentralContext.Dispose();
                this._ergCentralContext = null;
            }
        }
        #endregion

        #region Getter methods
        public IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = dbSet;
            return query;
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.FirstOrDefault(filter);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQuery(filter, includeProperties);

            if (orderBy != null)
                return orderBy(query).ToList();

            return query.ToList();
        }

        public List<TEntity> Get(int limit, int skip, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQuery(filter, includeProperties);

            if (orderBy != null)
                return orderBy(query).Skip(skip).Take(limit).ToList();

            return query.Skip(skip).Take(limit).ToList();
        }

        public List<TResult> GetAs<TResult>(Expression<Func<TEntity, TResult>> select, Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties) where TResult : class
        {
            var query = GetQuery(filter, includeProperties);
            return query.Select(select).ToList();
        }

        public Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetQuery(filter, includeProperties);
            if (orderBy != null)
                return orderBy(query).ToListAsync();

            return query.ToListAsync();
        }

        public Task<List<TEntity>> GetAsync(int limit, int skip, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {

            var query = GetQuery(filter, includeProperties);

            if (orderBy != null)
                return orderBy(query).Skip(skip).Take(limit).ToListAsync();

            return query.Skip(skip).Take(limit).ToListAsync();
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = GetQuery(filter);
            var count = query.Count();
            return count;
        }

        private IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            Type[] types = typeof(TEntity).GetInterfaces();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Any(filter);
        }

        #endregion


        #region CRUD operations
        public void Insert(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                _ergCentralContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity entityToUpdate)
        {
            if (_ergCentralContext.Entry(entityToUpdate).State == EntityState.Detached)
                dbSet.Attach(entityToUpdate);

            _ergCentralContext.Entry(entityToUpdate).State = EntityState.Modified;
            _ergCentralContext.SaveChanges();
        }
        public void Delete(TEntity entityToDelete)
        {
            if (_ergCentralContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            _ergCentralContext.SaveChanges();
        }

        public void InsertAll(List<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                dbSet.Add(entity);
            }
            _ergCentralContext.SaveChanges();
        }

        public void DeleteAll(List<TEntity> entities)
        {
            foreach (var entityToDelete in entities)
            {
                if (_ergCentralContext.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
                _ergCentralContext.SaveChanges();
            }
        }

        public void UpdateAll(List<TEntity> entities)
        {
            foreach (var entityToUpdate in entities)
            {
                if (_ergCentralContext.Entry(entityToUpdate).State == EntityState.Detached)
                    dbSet.Attach(entityToUpdate);
                _ergCentralContext.Entry(entityToUpdate).State = EntityState.Modified;
            }
            _ergCentralContext.SaveChanges();
        }
        #endregion
    }
}
