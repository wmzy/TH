using TH.Model;
using TH.Repositories.Infrastructure;

namespace TH.Repositories.Repository
{
    public class DetectionRepository : RepositoryBase<Detection>, IDetectionRepository
    {
        public DetectionRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IDetectionRepository : IRepository<Detection>
    {
    }
}