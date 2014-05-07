using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace TH.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> Get<TOderKey>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, TOderKey>> sortKeySelector, bool isAsc = true);
        
        int Count(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity instance);
        void Add(TEntity instance);
        void Delete(TEntity instance);
        void Delete(Expression<Func<TEntity, bool>> where);
    }
}