using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data;
using System.Collections.Generic;

namespace TH.Repositories
{
    public class THRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public THDbContext DbContext { get; private set; }
        public DbSet<TEntity> DbSet { get; private set; }
        public THRepository(THDbContext context)
        {
            this.DbContext = context;
            this.DbSet = DbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Get()
        {
            return this.DbSet.AsQueryable();
        }
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return this.DbSet.Where(filter).AsQueryable();
        }
        public IQueryable<TEntity> Get<TKey>(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, Expression<Func<TEntity, TKey>> sortKeySelector, bool isAsc = true)
        {
            if (isAsc)
            {
                return this.DbSet
                    .Where(filter)
                    .OrderBy(sortKeySelector)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
            else
            {
                return this.DbSet
                    .Where(filter)
                    .OrderByDescending(sortKeySelector)
                    .Skip(pageSize * (pageIndex - 1))
                    .Take(pageSize).AsQueryable();
            }
        }
        
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate).Count();
        }

        public void Add(TEntity instance)
        {
            this.DbSet.Attach(instance);
            this.DbContext.Entry(instance).State = EntityState.Added;
            
            this.DbContext.SaveChanges();
        }
        public void Update(TEntity instance)
        {
            this.DbSet.Attach(instance);
            this.DbContext.Entry(instance).State = EntityState.Modified;
            this.DbContext.SaveChanges();
        }
        public void Delete(TEntity instance)
        {
            this.DbSet.Attach(instance);
            this.DbContext.Entry(instance).State = EntityState.Deleted;
            this.DbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }
    }
}