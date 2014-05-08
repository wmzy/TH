
namespace TH.Repositories.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private THDbContext _dataContext;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected THDbContext DataContext
        {
            get { return _dataContext ?? (_dataContext = databaseFactory.Get()); }
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public void Rollback()
        {
            DataContext.Dispose();
        }
    }
}
