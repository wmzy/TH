using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace TH.Repositories
{
    public class THRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public THDbContext DbContext { get; private set; }
        public DbSet<TEntity> DbSet { get; private set; }
        public THRepository(THDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return DbSet.AsQueryable();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter).AsQueryable();
        }
        public IQueryable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> sortKeySelector, bool isAsc = true)
        {
            if (isAsc)
            {
                return DbSet
                    .Where(filter)
                    .OrderBy(sortKeySelector)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }

            return DbSet
                .Where(filter)
                .OrderByDescending(sortKeySelector)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize).AsQueryable();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).Count();
        }

        public void Add(TEntity instance)
        {
            DbSet.Attach(instance);
            DbContext.Entry(instance).State = EntityState.Added;
            
            DbContext.SaveChanges();
        }
        public void Update(TEntity instance)
        {
            DbSet.Attach(instance);
            DbContext.Entry(instance).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
        public void Delete(TEntity instance)
        {
            DbSet.Attach(instance);
            DbContext.Entry(instance).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (DbContext != null)
            {
                DbContext.Dispose();
            }
        }
    }
}