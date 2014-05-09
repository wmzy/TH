using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class UseMachineRepository : RepositoryBase<UseMachine>, IUseMachineRepository
    {
        public UseMachineRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IUseMachineRepository : IRepository<UseMachine>
    {
    }
}