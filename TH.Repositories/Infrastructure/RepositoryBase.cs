using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TH.Repositories.Infrastructure
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private THDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<TEntity>();
        }

        protected IDatabaseFactory DatabaseFactory{get;private set;}

        protected THDbContext DataContext
        {
            get { return _dbContext ?? (_dbContext = DatabaseFactory.Get()); }
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet.AsQueryable();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).AsQueryable();
        }
        public IQueryable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> sortKeySelector, bool isAsc = true)
        {
            if (isAsc)
            {
                return _dbSet.Where(filter).OrderBy(sortKeySelector).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            }

            return _dbSet.Where(filter).OrderByDescending(sortKeySelector).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).Count();
        }

        public void Add(TEntity instance)
        {
            _dbSet.Add(instance);
            //_dbSet.Attach(instance);
            //_dbContext.Entry(instance).State = EntityState.Added;
        }
        public void Update(TEntity instance)
        {
            _dbSet.Attach(instance);
            DataContext.Entry(instance).State = EntityState.Modified;
        }
        public void Delete(TEntity instance)
        {
            _dbSet.Remove(instance);
        }
        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            var instances = _dbSet.Where(where);
            foreach (var instance in instances)
                _dbSet.Remove(instance);
        }
    }
}