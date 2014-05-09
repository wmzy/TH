using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class FinancingRepository : RepositoryBase<Financing>, IFinancingRepository
    {
        public FinancingRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IFinancingRepository : IRepository<Financing>
    {
    }
}