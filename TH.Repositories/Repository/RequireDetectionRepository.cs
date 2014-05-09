using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class RequireDetectionRepository : RepositoryBase<RequireDetection>, IRequireDetectionRepository
    {
        public RequireDetectionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IRequireDetectionRepository : IRepository<RequireDetection>
    {
    }
}